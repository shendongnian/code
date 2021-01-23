    public interface IGenericIocFactory
    {
        T Get<T>(params object[] constructorParams) where T: class;
    }
    public interface ICustomAutoFacContainer
    {
        IContainer BindAndReturnCustom<T>(IComponentContext context, Type[] paramsList);
    }
    public class CustomAutoFacContainer : ICustomAutoFacContainer
    {
        public IContainer BindAndReturnCustom<T>(IComponentContext context, Type[] paramsList)
        {
            if (context.IsRegistered<T>())
            {
                // Get the current DI binding type target
                var targetType = context
                    .ComponentRegistry
                    .Registrations
                    .First(r => ((TypedService) r.Services.First()).ServiceType == typeof(T))
                    .Target
                    .Activator
                    .LimitType;
                // todo: exception handling and what not .targetType
                var builder = new ContainerBuilder();
                builder
                   .RegisterType(targetType)
                   .As<T>()
                   .UsingConstructor(paramsList)
                   .PropertiesAutowired();
                return builder.Build();
            }
            return null;
        }
    }
    public class GenericIocFactory : IGenericIocFactory
    {
        private ICustomAutoFacContainer _iCustomContainer;
        private readonly IComponentContext _icoContext;
        public GenericIocFactory(ICustomAutoFacContainer iCustomContainer, IComponentContext icoContext)
        {
             _iCustomContainer = iCustomContainer;
            _icoContext = icoContext;
        }
        public T Get<T>(params object[] constructorParams) where T: class
        {
            //TODO handle reflection generation? ?? ?not needed?? ??
            var parameters = constructorParams
                .Select((t, index) => new PositionalParameter(index, t))
                .Cast<Parameter>()
                .ToList();
            var parameterTypes = constructorParams
                .Select((t, index) => t.GetType())
                .ToArray();
            return _iCustomContainer
                .BindAndReturnCustom<T>(_icoContext,parameterTypes)
                .Resolve<T>(parameters);
        }
    }
