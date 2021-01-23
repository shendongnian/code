        public class DependenciesFromAppSettingsResolver : ISubDependencyResolver
    {
        private readonly IDictionary<string, string> webConfig;
        public DependenciesFromAppSettingsResolver(IDictionary<string, string> webConfig)
        {
            /// you can pass in your configprovider object here (or similar)
            this.webConfig = webConfig;
        }
        public bool CanResolve(Castle.MicroKernel.Context.CreationContext context, 
            ISubDependencyResolver contextHandlerResolver, 
            Castle.Core.ComponentModel model, 
            Castle.Core.DependencyModel dependency)
        {
            //make sure your connectionstring has value
        }
        public object Resolve(Castle.MicroKernel.Context.CreationContext context, 
            ISubDependencyResolver contextHandlerResolver, 
            Castle.Core.ComponentModel model, 
            Castle.Core.DependencyModel dependency)
        {
            //resolve your connectionstring here
        }
    }
