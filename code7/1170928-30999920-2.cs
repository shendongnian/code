    class TestRegistrationSource : IRegistrationSource
    {
        public Boolean IsAdapterForIndividualComponents
        {
            get { return false; }
        }
        public IEnumerable<IComponentRegistration> RegistrationsFor(
            Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            IServiceWithType typedService = service as IServiceWithType;
            if (typedService == null)
            {
                yield break;
            }
            if (!(typedService.ServiceType.IsGenericType 
                  && typedService.ServiceType.GetGenericTypeDefinition() == typeof(IAdapter<>)))
            {
                yield break;
            }
            Type t = typedService.ServiceType.GetGenericArguments()[0];
            IComponentRegistration registration = 
                RegistrationBuilder.ForDelegate((c, p) => c.ResolveNamed(t.Namespace, typedService.ServiceType, p))
                                   .As(service)
                                   .CreateRegistration();
            yield return registration;
        }
    }
