    public class GISGoogleQueue : BaseMessageQueue
    {
        System.Threading.Thread _thread;
        System.Threading.ManualResetEvent _shutdownEvent;
        public GISGoogleQueue(string queueName, int threadCount, GACLogger logger, int messagesPerThread)
             : base(queueName, threadCount, logger, messagesPerThread)
        {
            // Let this class wrap a thread object.  Create it here.
            _thread = new Thread(RunMessageQueueFunc()
                      {
                          Name = "Run Message Queue Thread " + Guid.NewGuid().ToString(),
                          IsBackground = true
                      };
            _shutdownEvent = new ManualResetEvent(false);
        }
        public Start()
        {
            _thread.Start();
        }
        public Shutdown()
        {
            _shutdownEvent.Set();
            if (!_thread.Join(5000))
            {
                // give the thread 5 seconds to stop
                _thread.Abort();
            }
        }
        private void RunMessageQueueFunc()
        {
            if (!MessageQueue.Exists(base.QueueName))
            {
                _logger.LogMessage(MessageType.Information, string.Format("Queue '{0}' doesn't exist", this.QueueName));
                return;
            }
            var messageQueue = new MessageQueue(QueueName);
            var myVehMonLog = new VehMonLog();
            var o = new Object();
            var arrTypes = new Type[2];
            arrTypes[0] = myVehMonLog.GetType();
            arrTypes[1] = o.GetType();
            messageQueue.Formatter = new XmlMessageFormatter(arrTypes);
            using (var pool = new Pool(ThreadCount))
            {
                // Here's where we'll wait for the shutdown event to occur.
                while (!_shutdownEvent.WaitOne(0))
                {
                    for (var i = 0; i < MessagesPerThread; i++)
                    {
                        try
                        {
                            // Stop execution until Tasks in pool have been executed
                            while (pool.TaskCount() >= MessagesPerThread) ;
                            // TimeOut for message reading from Queue, set to 5 minutes, Will throw exception after 5 mins
                            var message = messageQueue.Receive(new TimeSpan(0, 0, 5, 0));
                            if (message != null) // Check if message is not Null
                            {
                                var monLog = (VehMonLog)message.Body;
                                pool.QueueTask(() => ProcessMessageFromQueue(monLog)); // Add to Tasks list in Pool
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
        }
    }
