    using Autofac;
    using Autofac.Builder;
    using Autofac.Core;
    using Microsoft.AspNet.SignalR;
    using System;
    using System.Collections.Generic; 
    using System.Linq;
    namespace LabCommunicator.Server.Configuration
    {
        internal class AutofacSignalrDependencyResolver : DefaultDependencyResolver, IRegistrationSource
        {
            private ILifetimeScope LifetimeScope { get; set; }
            public AutofacSignalrDependencyResolver(ILifetimeScope lifetimeScope)
            {
                LifetimeScope = lifetimeScope;
                var currentRegistrationSource = LifetimeScope.ComponentRegistry.Sources.FirstOrDefault(s => s.GetType() == GetType());
                if (currentRegistrationSource != null)
                {
                    ((AutofacSignalrDependencyResolver)currentRegistrationSource).LifetimeScope = lifetimeScope;
                }
                else
                {
                    LifetimeScope.ComponentRegistry.AddRegistrationSource(this);
                }
            }
            public override object GetService(Type serviceType)
            {
                object result;
                if (LifetimeScope == null)
                {
                    return base.GetService(serviceType);
                }
                if (LifetimeScope.TryResolve(serviceType, out result))
                {
                    return result;
                }
                return null;
            }
            public override IEnumerable<object> GetServices(Type serviceType)
            {
                object result;
                if (LifetimeScope == null)
                {
                    return base.GetServices(serviceType);
                }
                if (LifetimeScope.TryResolve(typeof(IEnumerable<>).MakeGenericType(serviceType), out result))
                {
                    return (IEnumerable<object>)result;
                }
                return Enumerable.Empty<object>();
            }
            public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
            {
                var typedService = service as TypedService;
                if (typedService != null)
                {
                    var instances = base.GetServices(typedService.ServiceType);
                    if (instances != null)
                    {
                        return instances
                            .Select(i => RegistrationBuilder.ForDelegate(i.GetType(), (c, p) => i).As(typedService.ServiceType)
                            .InstancePerLifetimeScope()
                            .PreserveExistingDefaults()
                            .CreateRegistration());
                    }
                }
                return Enumerable.Empty<IComponentRegistration>();
            }
            bool IRegistrationSource.IsAdapterForIndividualComponents
            {
                get { return false; }
            }
        }
    }
