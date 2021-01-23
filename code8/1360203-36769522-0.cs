    public class TestModule : Module
    {
        protected override void AttachToComponentRegistration(
            IComponentRegistry componentRegistry,
            IComponentRegistration registration)
        {
            registration.Preparing += (sender, e) =>
            {
                Parameter parameter = new ResolvedParameter(
                    (pi, c) =>
                    {
                        return pi.ParameterType == typeof(ILogger);
                    }, (pi, c) =>
                    {
                        var p = new TypedParameter(typeof(Type), 
                                                   e.Component.Activator.LimitType);
                        return c.Resolve<ILogger>(p);
                    });
                e.Parameters = e.Parameters.Union(new Parameter[] { parameter });
            };
            base.AttachToComponentRegistration(componentRegistry, registration);
        }
    }
