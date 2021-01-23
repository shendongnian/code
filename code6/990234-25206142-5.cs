        /// <summary>
        /// Inherit from this class in order to customize the configuration of the framework.
        /// </summary>
        public abstract class BootstrapperBase {
        
        ... left out for brevity
        /// <summary>
        /// Override to tell the framework where to find assemblies to inspect for views, etc.
        /// </summary>
        /// <returns>A list of assemblies to inspect.</returns>
        protected virtual IEnumerable<Assembly> SelectAssemblies() {
            return new[] { GetType().Assembly };
        }
