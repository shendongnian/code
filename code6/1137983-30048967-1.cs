    public class FeedMuxMessageBroker : IMessageBroker<Taurus.FeedMux>, IDisposable
    {
        // Vars.
        private NetMQContext context;
        private PublisherSocket pubSocket;
        private Poller poller;
        private CancellationTokenSource source;
        private CancellationToken token;
        private ManualResetEvent pollerCancelled;
        /// <summary>
        /// Default ctor.
        /// </summary>
        public FeedMuxMessageBroker()
        {
            context = NetMQContext.Create();
            pubSocket = context.CreatePublisherSocket();
            pubSocket.Connect(PublisherAddress);
            pollerCancelled = new ManualResetEvent(false);
            source = new CancellationTokenSource();
            token = source.Token;
            StartPolling();
        }
        #region Methods.
        /// <summary>
        /// Send the mux message to listners.
        /// </summary>
        /// <param name="message">The message to dispatch.</param>
        public void Dispatch(Taurus.FeedMux message)
        {
            pubSocket.Send(message.ToByteArray<Taurus.FeedMux>());
        }
        /// <summary>
        /// Start polling for messages.
        /// </summary>
        private void StartPolling()
        {
            Task.Run(() =>
                {
                    using (var subSocket = context.CreateSubscriberSocket())
                    {
                        byte[] buffer = null;
                        subSocket.Options.ReceiveHighWatermark = 1000;
                        subSocket.Connect(SubscriberAddress);
                        subSocket.Subscribe(String.Empty);
                        subSocket.ReceiveReady += (s, a) =>
                        {
                            buffer = subSocket.Receive();
                            if (MessageRecieved != null)
                                MessageRecieved.Report(buffer.ToObject<Taurus.FeedMux>());
                        };
                        // Poll.
                        poller = new Poller();
                        poller.AddSocket(subSocket);
                        poller.PollTillCancelled();
                        token.ThrowIfCancellationRequested();
                    }
                }, token).ContinueWith(ant => 
                    {
                        pollerCancelled.Set();
                    }, TaskContinuationOptions.OnlyOnCanceled);
        }
        /// <summary>
        /// Cancel polling to allow the broker to be disposed.
        /// </summary>
        private void CancelPolling()
        {
            source.Cancel();
            poller.Cancel();
            pollerCancelled.WaitOne();
            pollerCancelled.Close();
        }
        #endregion // Methods.
        #region Properties.
        /// <summary>
        /// Event that is raised when a message is recived. 
        /// </summary>
        public IProgress<Taurus.FeedMux> MessageRecieved { get; set; }
        /// <summary>
        /// The address to use for the publisher socket.
        /// </summary>
        public string PublisherAddress { get { return "tcp://127.0.0.1:6500"; } }
        /// <summary>
        /// The address to use for the subscriber socket.
        /// </summary>
        public string SubscriberAddress { get { return "tcp://127.0.0.1:6501"; } }
        #endregion // Properties.
        #region IDisposable Members.
        private bool disposed = false;
        /// <summary>
        /// Dispose managed resources.
        /// </summary>
        /// <param name="disposing">Is desposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    CancelPolling();
                    if (pubSocket != null)
                    {
                        pubSocket.Disconnect(PublisherAddress);
                        pubSocket.Dispose();
                        pubSocket = null;
                    }
                    if (poller != null)
                    {
                        poller.Dispose();
                        poller = null;
                    }
                    if (context != null)
                    {
                        context.Terminate();
                        context.Dispose();
                        context = null;
                    }
                    if (source != null)
                    {
                        source.Dispose();
                        source = null;
                    }
                }
                // Shared cleanup logic.
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Finalizer.
        /// </summary>
        ~FeedMuxMessageBroker()
        {
            Dispose(false);
        }
        #endregion // IDisposable Members.
    }
