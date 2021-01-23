    class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceContainer();
            container.Register<AbstractValidator<Foo>, FooValidator>();    
            container.Register<IFooService, FooService>();
            container.Intercept(sr => sr.ServiceType.Name.EndsWith("Service"), factory => new ServiceInterceptior(factory));
            var service = container.GetInstance<IFooService>();
            service.Add(new Foo());
        }
    }
    public interface IFooService
    {
        void Add(Foo foo);
    }
    public class FooService : IFooService
    {
        public void Add(Foo foo)
        {
        }
    }
    public class Foo
    {
    }
    public class FooValidator : AbstractValidator<Foo>
    {
    }
    public class ServiceInterceptior : IInterceptor
    {
        private readonly IServiceFactory factory;
        public ServiceInterceptior(IServiceFactory factory)
        {
            this.factory = factory;
        }
        public object Invoke(IInvocationInfo invocationInfo)
        {
            foreach (var argument in invocationInfo.Arguments)
            {
                Type argumentType = argument.GetType();
                Type validatorType = typeof (AbstractValidator<>).MakeGenericType(argumentType);
                var validator = factory.TryGetInstance(validatorType);
                if (validator != null)
                {
                    var validateMethod = validatorType.GetMethod("Validate", new Type[] { argumentType });
                    var result = (ValidationResult)validateMethod.Invoke(validator, new object[] { argument });
                    if (!result.IsValid)
                    {
                        //Throw an exception, log or any other action
                    }
                }                
            }
            //if ok, proceed to the actual service.
            return invocationInfo.Proceed();
        }
    }
