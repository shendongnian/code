    public class LoggingModule : Autofac.Module
    {
        protected override void AttachToComponentRegistration(
            IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing += (sender, e) =>
            {
                Type limitType = e.Component.Activator.LimitType;
                e.Parameters = e.Parameters.Union(new[] {
                    new ResolvedParameter((pi, c) => pi.ParameterType == typeof(ILogger), 
                                          (pi, c) => c.Resolve<ILogger>(new NamedParameter("name", limitType.Name))),
                });
            };
        }
    }
