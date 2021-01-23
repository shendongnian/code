    public abstract class BaseJob 
    {
        public bool IsRunning { get; private set; }
        public void Run() 
        {
            IsRunning = true;
            RunInner();
            IsRunning = false;
        }
        public abstract void RunInner();
    }
