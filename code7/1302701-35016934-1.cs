        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<IOptions<AppSettings>>(_app.ApplicationServices.GetService<IOptions<AppSettings>>());
        }
