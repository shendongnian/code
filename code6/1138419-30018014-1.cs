    class SendMessageQueue : IDisposable
    {
        private bool m_Disposed;
        private bool m_CompleteSending;
        private Task m_SendingTask;
        private AsyncMonitor m_Monitor;
        private List<MessageTaskCompletionSource> m_MessageCollection;
        private ISendMessageService m_SendMessageService;
        public int Capacity { get; private set; }
        public SendMessageQueue(int capacity, ISendMessageService service)
        {
            Capacity = capacity;
            m_Monitor = new AsyncMonitor();
            m_MessageCollection = new List<MessageTaskCompletionSource>();
            m_SendMessageService = service;
            m_SendingTask = StartSendingAsync();
        }
        public async Task<bool> SendAsync(string message, CancellationToken token)
        {
            if (m_Disposed) { throw new ObjectDisposedException(GetType().Name); }
            if (message == null) { throw new ArgumentNullException("message"); }
            using (var messageTcs = new MessageTaskCompletionSource(message, token))
            {
                await AddAsync(messageTcs);
                return await messageTcs.Task;
            }
        }
        public async Task CompleteSendingAsync()
        {
            if (m_Disposed) { throw new ObjectDisposedException(GetType().Name); }
            using (m_Monitor.Enter())
            {
                m_CompleteSending = true;
            }
            await m_SendingTask;
        }
        private async Task AddAsync(MessageTaskCompletionSource message)
        {
            using (await m_Monitor.EnterAsync(message.Token))
            {
                if (m_CompleteSending) { throw new InvalidOperationException("Queue already completed."); }
                if (Capacity < m_MessageCollection.Count)
                {
                    m_MessageCollection.RemoveAll(item => item.IsCanceled);
                    if (Capacity < m_MessageCollection.Count)
                    {
                        throw new QueueOverflowException(string.Format("Queue overflow; '{0}' couldn't be enqueued.", message.Message));
                    }
                }
                m_MessageCollection.Add(message);
            }
            m_Monitor.Pulse(); // signal new message
            Console.WriteLine("Thread '{0}' - {1}: '{2}' enqueued.", Thread.CurrentThread.ManagedThreadId, DateTime.Now.TimeOfDay, message.Message);
        }
        private async Task<MessageTaskCompletionSource> TakeAsync()
        {
            using (await m_Monitor.EnterAsync())
            {
                var message = m_MessageCollection.ElementAt(0);
                m_MessageCollection.RemoveAt(0);
                return message;
            }
        }
        private async Task<bool> OutputAvailableAsync()
        {
            using (await m_Monitor.EnterAsync())
            {
                if (m_MessageCollection.Count > 0) { return true; }
                else if (m_CompleteSending) { return false; }
                await m_Monitor.WaitAsync();
                return true;
            }
        }
        private async Task StartSendingAsync()
        {
            while (await OutputAvailableAsync())
            {
                var message = await TakeAsync();
                if (message.IsCanceled) continue;
                try
                {
                    var result = await m_SendMessageService.SendMessageAsync(message.Message, message.Token);
                    message.TrySetResult(result);
                }
                catch (TaskCanceledException) { message.TrySetCanceled(); }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (m_Disposed) return;
            if (disposing)
            {
                if (m_MessageCollection != null)
                {
                    var tmp = m_MessageCollection;
                    m_MessageCollection = null;
                    tmp.ForEach(item => item.Dispose());
                    tmp.Clear();
                }
            }
            m_Disposed = true;
        }
        #region MessageTaskCompletionSource Class
        class MessageTaskCompletionSource : TaskCompletionSource<bool>, IDisposable
        {
            private bool m_Disposed;
            private IDisposable m_CancellationTokenRegistration;
            public string Message { get; private set; }
            public CancellationToken Token { get; private set; }
            public bool IsCompleted { get { return Task.IsCompleted; } }
            public bool IsCanceled { get { return Task.IsCanceled; } }
            public bool IsFaulted { get { return Task.IsFaulted; } }
            public MessageTaskCompletionSource(string message, CancellationToken token)
            {
                m_CancellationTokenRegistration = token.Register(() => TrySetCanceled());
                Message = message;
                Token = token;
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected void Dispose(bool disposing)
            {
                if (m_Disposed) return;
                if (disposing)
                {
                    TrySetException(new ObjectDisposedException(GetType().Name));
                    if (m_CancellationTokenRegistration != null)
                    {
                        var tmp = m_CancellationTokenRegistration;
                        m_CancellationTokenRegistration = null;
                        tmp.Dispose();
                    }
                }
                m_Disposed = true;
            }
        }
        #endregion
    }
