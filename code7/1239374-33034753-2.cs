    public class Worker
    {
        public string GetContextName()
        {
            WorkerContext context = CreateWorkerContext();
            return context.Name;
        }
        public virtual WorkerContext CreateWorkerContext()
        {
            return new WorkerContext();
        }
    }
