    public class LogicAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.EnumerateAttributedTypes<LogicAttribute>((type, attribute) =>
            {
                // ReSharper disable once ConvertToLambdaExpression
                builder
                    .RegisterType(type)
                    .Keyed(attribute.Metadata.LoginState, typeof (ILogic<,>))
                    .As(typeof (ILogic<,>));
            });         
        }
    }
