        public class NLoggerTraceWriterModule : Module
    {
        private HttpConfiguration _config;
        public NLoggerTraceWriterModule(HttpConfiguration config)
        {
            this._config = config;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(this._config).As<HttpConfiguration>();
            builder.Register(c =>
                               c.Resolve<HttpConfiguration>()
                                .Services
                                .GetService(typeof(ITraceWriter)) as ITraceWriter)
                   .As<ITraceWriter>();
        }
    }
