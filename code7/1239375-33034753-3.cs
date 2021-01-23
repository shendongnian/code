    public class Worker
    {
        private readonly IWorkerContextFactory factory;
        public Worker(IWorkerContextFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));
            this.factory = factory;
        }
        public string GetContextName()
        {
            WorkerContext context = this.factory.Create();
            return context.Name;
        }
    }
