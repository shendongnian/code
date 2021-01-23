        protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<System.Web.Script.Serialization.JavaScriptSerializer>(CustomJsonSerializer);
        }
