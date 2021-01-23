    public class ThreadedWorker
    {
        bool endMe = false;
        public bool EndSignalled { get { return Volatile.Read(ref endMe); } }
        public void SignalEnd()
        {
            Volatile.Write(ref isEnded, true);
        }
    }
