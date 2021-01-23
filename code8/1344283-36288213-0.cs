    public abstract class Worker
    {
        public void DoWork()
        {
             if (Work != null)
             {
                 Prepare();
                 Work();
                 Cleanup();
             }
        }
    
        protected Action Work { private get; set; }
    }
    public class ImplWorker {
        public ImplWorker() {
            Work = //whatever
        }
    }
