        public class MyOwnProgressHandlerContainer
        {
            private readonly long _expectedBytesTransferred;
            private long _lastRecoredBytesTransferred = 0;
            public MyOwnProgressHandlerContainer(long expectedBytesTransferred)
            {
                _expectedBytesTransferred = expectedBytesTransferred;
            }
            public void ReceivedProgressHandler(object sender, HttpProgressEventArgs e)
            {
                // you can uses e.ProgressPercentage but this is calculated based on content length
                // http header which is very much ignored nowadays
                if (_lastRecoredBytesTransferred != 0 && e.BytesTransferred < (_lastRecoredBytesTransferred + _expectedBytesTransferred))
                    throw new Exception("Too Slow, Abort !");
                _lastRecoredBytesTransferred = e.BytesTransferred;
            }
            public void SendProgressHandler(object sender, HttpProgressEventArgs e)
            {
                // write stuff to handle here when sending data (mainly for post or uploads)
                Console.WriteLine("Sent data ...");
            }
        }
