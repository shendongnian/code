            while (!_shutdownEvent.WaitOne(0))
            {
                TestMessageQueueReader processQueue = new TestMessageQueueReader();
                processQueue.ReadFromQueue();
            }
 
