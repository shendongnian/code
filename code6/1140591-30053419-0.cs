    public interface ISomeClass2
    {
        void DoSomething();
        void RegisterProcessingServiceType(Type processingServiceType);
    }
    public class SomeClass2 : ISomeClass2
    {
        private Type _type;
        public void DoSomething()
        {
            if(_type == null)
                throw InvalidOperationException("Register processing service type before doing stuff.");
            // actually do something
        }
        public void RegisterProcessingServiceType(Type serviceType)
        {
            _type = serviceType;
        }
    }
    internal class ProcessingService: IProcessingService
    {
        private readonly ISomeClass1 someClass1;
        private readonly ISomeClass2 someClass2;
        public ProcessingService(ISomeClass1 someClass1, ISomeClass2 someClass2)
        {
            this.someClass1 = someClass1;
            this.someClass2 = someClass2;
            this.someClass2.RegisterProcessingServiceType(this.GetType());
        }
    }
