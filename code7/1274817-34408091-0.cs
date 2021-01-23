        this.Bind<ILogger>().ToMethod(context =>
        {
            var typeForLogger = context.Request.Target != null
                                    ? context.Request.Target.Member.DeclaringType
                                    : context.Request.Service;
            return context.Kernel.Get<ILoggerFactory>().GetLogger(typeForLogger);
        });
