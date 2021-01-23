    public class OwnedPerRequest<T> : Owned<T>
    {
        public OwnedPerRequest(T value, IDisposable lifetime) : base(value, lifetime) { }
    }
    
    public class OwnedPerRequestInstanceRegistrationSource : IRegistrationSource
    {
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            if (registrationAccessor == null)
                throw new ArgumentNullException(nameof(registrationAccessor));
    
            var swt = service as IServiceWithType;
            if (swt == null
                 || !(swt.ServiceType.IsGenericType
                        && swt.ServiceType.GetGenericTypeDefinition() == typeof(OwnedPerRequest<>)))
                return Enumerable.Empty<IComponentRegistration>();
    
            var ownedInstanceType = swt.ServiceType.GetGenericArguments()[0];
            var ownedInstanceService = swt.ChangeType(ownedInstanceType);
    
            return registrationAccessor(ownedInstanceService)
                .Select(r =>
                {
                    var rb = RegistrationBuilder.ForDelegate(swt.ServiceType, (c, p) =>
                    {
                        var lifetime = c.Resolve<ILifetimeScope>().BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
                        try
                        {
                            var value = lifetime.ResolveComponent(r, p);
                            return Activator.CreateInstance(swt.ServiceType, value, lifetime);
                        }
                        catch
                        {
                            lifetime.Dispose();
                            throw;
                        }
                    });
    
                    return rb
                        .ExternallyOwned()
                        .As(service)
                        .Targeting(r)
                        .CreateRegistration();
                });
        }
    
        public bool IsAdapterForIndividualComponents => true;
    
        public override string ToString() => "OwnedPerRequestInstanceregistrationSource";
    }
