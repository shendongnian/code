        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
            var requestUrl = container.Resolve<IRequestUrl>();
            requestUrl.Context = context;
        }
    }
