    public class Mouse_Tracking
    {
        private ManualResetEvent _stopEvent = new ManualResetEvent(false);
        public void stop()
        {
            _stopEvent.Set();
        }
        public void run()
        {
            while (true)
            {
                if (_stopEvent.WaitOne(0))
                {
                    //Console.WriteLine("stop");
                    // handle stop
                    return;
                }
                //Console.WriteLine("action!");
                // some actions
                Thread.Sleep(1000);
            }
        }
    }
