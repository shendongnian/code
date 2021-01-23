    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Web.Api.Host
    {
        class WindsorInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(Component
                    .For<Controllers.V1.IPerWebRequestDependency>()
                    .ImplementedBy<Controllers.V1.PerWebRequestDependency>()
                    .LifestyleScoped<OwinWebRequestScopeAccessor>());
                container.Register(Component
                    .For<Controllers.V1.TestController>()
                    .LifeStyle.Transient);
            }
        }
    }
