    public static class PreApplicationStart
    {
        private const string TraceName = "Microsoft.Owin.Host.SystemWeb.PreApplicationStart";
        /// <summary>
        /// Registers the OWIN request processing module.
        /// </summary>
        public static void Initialize()
        {
            try
            {
                if (OwinBuilder.IsAutomaticAppStartupEnabled)
                {
                    HttpApplication.RegisterModule(typeof(OwinHttpModule));
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                ITrace trace = TraceFactory.Create("Microsoft.Owin.Host.SystemWeb.PreApplicationStart");
                trace.WriteError(Resources.Trace_RegisterModuleException, exception);
                throw;
            }
        }
    }
