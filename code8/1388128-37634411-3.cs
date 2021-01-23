    public class CAssemblyResolveHttpModule : IHttpModule
    {
        public void Init(System.Web.HttpApplication iContext)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }
        private Assembly CurrentDomain_AssemblyResolve(
            object iSender,
            ResolveEventArgs iArgs)
        {
            return Assembly.LoadFrom(...);
        }
    }
