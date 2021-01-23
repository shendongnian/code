    public interface IGenericSomeClass2<T>: ISomeClass2 {}
    public class GenericSomeClass2<T>: IGenericSomeClass2<T>
    {
        private readonly ISomeClass2 someClass2;
        public GenericSomeClass2()
        {
            this.someClass2 = new SomeClass2(typeof(T));
        }
        // Pass-through implementation
    }
    public IUnityContainer Configure(IUnityContainer container)
    {
        return container
            .RegisterType<ISomeClass1, SomeClass1>()
            .RegisterType(typeof(IGenericSomeClass2<>), typeof(GenericSomeClass2<>));
    }
    internal class ProcessingService: IProcessingService
    {
        private readonly ISomeClass1 someClass1;
        private readonly ISomeClass2 someClass2;
        public ProcessingService(ISomeClass1 someClass1, IGenericSomeClass2<ProcessingService> someClass2)
        {
            this.someClass1 = someClass1;
            this.someClass2 = someClass2;
        }
    }
