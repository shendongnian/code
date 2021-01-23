    public class DefaultRegistry : Registry 
    {
        public DefaultRegistry() 
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType<BusinessClass>();
                    scan.WithDefaultConventions();
                });            
        }
    }
