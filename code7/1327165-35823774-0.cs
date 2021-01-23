    using System;
    using Castle.Facilities.WcfIntegration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    namespace WcfService1
    {
        public class Global : System.Web.HttpApplication
        {
            static readonly IWindsorContainer Container = new WindsorContainer();
            protected void Application_Start(object sender, EventArgs e)
            {
                ConfigureContainer();
            }
            private void ConfigureContainer()
            {
                Container.AddFacility<WcfFacility>();
                Container.Install(FromAssembly.This());
            }
        }
    }
