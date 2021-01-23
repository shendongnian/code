    public class AppSettingsResolver : ISubDependencyResolver
    {
        public bool CanResolve(
                    CreationContext context,
                    ISubDependencyResolver contextHandlerResolver,
                    ComponentModel model,
                    DependencyModel dependency)
        {
            return !string.IsNullOrEmpty(ConfigurationManager.AppSettings[dependency.DependencyKey])
                   &&
                   TypeDescriptor.GetConverter(dependency.TargetType)
                    .CanConvertFrom(typeof(string));
        }
        public object Resolve(
                        CreationContext context,
                        ISubDependencyResolver contextHandlerResolver,
                        ComponentModel model,
                        DependencyModel dependency)
        {
            return TypeDescriptor
                .GetConverter(dependency.TargetType)
                .ConvertFrom(ConfigurationManager.AppSettings[dependency.DependencyKey]);
        }
    }
