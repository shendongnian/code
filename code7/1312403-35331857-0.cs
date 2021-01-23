    public class LoggerExtension : UnityContainerExtension
    {
        public static NamedTypeBuildKey LoggerBuildKey = new NamedTypeBuildKey<Logger>();
        protected override void Initialize()
        {
            Context.Strategies.Add(new LoggerTrackingPolicy(), UnityBuildStage.TypeMapping);
            Context.Strategies.Add(new LoggingBuildUpStrategy(), UnityBuildStage.PreCreation);
        }
    }
    public class LoggingBuildUpStrategy : BuilderStrategy
    {
        public LoggingBuildUpStrategy()
        {
        }
        public override void PreBuildUp(IBuilderContext context)
        {
            if (context.BuildKey.Type == typeof(Logger))
            {
                var policy = context.Policies.Get<ILoggerPolicy>(LoggerExtension.LoggerBuildKey);
                Type type = policy.Pop();
                context.AddResolverOverrides(new ParameterOverride("type", 
                    new InjectionParameter(typeof(Type), type)));
            }
        }
    }
    public class LoggerTrackingPolicy : BuilderStrategy
    {
        public LoggerTrackingPolicy()
        {
        }
        public override void PreBuildUp(IBuilderContext context)
        {
            if (context.BuildKey.Type != typeof(Logger))
            {
                var loggerPolicy = context.Policies.Get<ILoggerPolicy>(LoggerExtension.LoggerBuildKey);
                if (loggerPolicy == null)
                {
                    loggerPolicy = new LoggerPolicy();
                    context.Policies.Set<ILoggerPolicy>(loggerPolicy, LoggerExtension.LoggerBuildKey);
                }
                loggerPolicy.Push(context.BuildKey.Type);
            }
        }
    }
    public interface ILoggerPolicy : IBuilderPolicy
    {
        void Push(Type type);
        Type Pop();
    }
    public class LoggerPolicy : ILoggerPolicy
    {
        private Stack<Type> types = new Stack<Type>();
        public void Push(Type type)
        {
            types.Push(type);
        }
        public Type Pop()
        {
            return types.Pop();
        }
    }
