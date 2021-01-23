    public class EventLog
    {
    public String LogPath { get; set; }
    public List<LogEvent> Events {get;set;}
    private isProcessing = false;
    public CancellationTokenSource cts = new CancellationTokenSource();
    private CancellationToken token;
    public static EventLog Instance { get { return lazyInstance.Value; } }
    private static readonly Lazy<EventLog> lazyInstance = new Lazy<EventLog>(() => new EventLog());
    private EventLog()
    {
        Events = new List<LogEvent>();
        Events.CollectionChanged += Events_CollectionChanged;
        LogPath = Assembly.GetExecutingAssembly().CodeBase;
        LogPath = Path.GetDirectoryName(LogPath);
        LogPath = LogPath.Replace("file:\\", "");
        LogPath = LogPath + "\\Log.txt";
        token = cts.Token; 
    }
    public override void publish(LogEvent newEvent)
    {
        Events.Add(newEvent);
        if (!isProcessing)
            ProcessLog();
    }
    private async void ProcessLog()
    {
        while (Events.Count > 0)
        {
            isProcessing = true;
            LogEvent e = EventLogs.First();
            await Task.Run (() => { //Write the log to file here },token);
            EventLogs.Remove(e);
            if (token.IsCancellationRequested == true)
                EventLogs.Clear();
        }
        isProcessing = false;
    }
