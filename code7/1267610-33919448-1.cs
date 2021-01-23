    /// <summary>
    /// Singleton that periodically checks the log database for new messages and broadcasts them to all
    /// connected web-clients (SignalR).
    /// </summary>
    public class LiveMessageTicker : ILiveMessageTicker, IRegisteredObject
    {
        private readonly TimeSpan updateInterval = TimeSpan.FromMilliseconds(2000);
        private readonly ILogEntriesRepository repository;
        private Guid lastLogEntryId = Guid.Empty;
        private readonly SemaphoreSlim checkSemaphore = new SemaphoreSlim(1, 2);
        private Timer checkTimer;
        private readonly IHubContext hub;
        /// <summary>
        /// Initializes a new instance of the <see cref="LiveMessageTicker"/> class.
        /// </summary>
        /// <param name="repository">The database repository to use.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public LiveMessageTicker(ILogEntriesRepository repository)
        {
            if (repository == null) { throw new ArgumentNullException(nameof(repository)); }
            this.repository = repository;
            // Register this instance to in ASP to free it up on shutdown
            HostingEnvironment.RegisterObject(this);
            // Get the server-side SignalR hub
            hub = GlobalHost.ConnectionManager.GetHubContext<ServerMonitoringHub>(); 
            // Configure a Timer that calls CheckForNewMessages all 2 sec's
            checkTimer = new Timer(CheckForNewMessages, null, TimeSpan.Zero, updateInterval);
        }
        /// <summary>
        /// Stops this instance.
        /// </summary>
        /// <param name="immediate">if set to <c>true</c> immediatelly.</param>
        /// <seealso cref="IRegisteredObject"/>
        public void Stop(bool immediate)
        {
            checkTimer.Dispose();
            checkTimer = null;
            HostingEnvironment.UnregisterObject(this);
        }
        private void CheckForNewMessages(object state)
        {
            if (checkSemaphore.Wait(500))
            {
                try
                {
                    // Get new log entries
                    var newLogEntries = repository.GetNewLogEntries(lastLogEntryId).ToList();
                    // If there arent any new log entries
                    if (!newLogEntries.Any())
                    {
                        return;
                    }
                    lastLogEntryId = newLogEntries.Last().Id;
                    // Convert DB entities into DTO's for specific client needs
                    var logEntries = newLogEntries.Select(l => new
                    {
                        id = l.Id,
                        correlationId = l.CorelationIdentifier,
                        messageId = l.MessageId,
                        time = l.Time.ToLocalTime(),
                        level = (int)l.Level,
                        messageText = l.Message,
                        additionalData = l.AdditionalData.Select(a => new { name = a.Name, value = a.Value }).ToArray(),
                        tags = l.Tags.Select(t => t.Name).ToArray(),
                        channel = l.Channel.Name,
                        username = l.Username,
                        workstation = l.WorkstationName
                    }).ToList();
                    // Broadcast all new log entries over SignalR
                    hub.Clients.All.addLogMessages(logEntries);
                }
                finally
                {
                    checkSemaphore.Release();
                }
            }
        }
    }
