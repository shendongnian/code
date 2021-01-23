    public abstract class ProcessorBase : IProcessor
    {
        protected IProcessor successor;
        public ProcessorBase(IProcessor successorObj)
        {
            this.successor = successorObj;
        }
        public bool Process(ProcessRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            if (this.IsResponsible(request.Type))
            {
                return this.InnerProcess(request);
            }
            else
            {
                return this.successor.Process(request);
            }
        }
        public abstract bool InnerProcess(ProcessRequest request);
        public abstract bool IsResponsible(ConfigType type);
    }
