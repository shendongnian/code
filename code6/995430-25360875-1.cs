    public class ThreadedWorker
    {
        volatile bool endMe = false;
        public bool EndSignalled { get { return endMe; } }
        public void SignalEnd()
        {
            endMe = true;
        }
    }
