    class CustomEnumerableRegistrationSource : IRegistrationSource
    {
        public Boolean IsAdapterForIndividualComponents
        {
            get
            {
                return false;
            }
        }
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            IServiceWithType typedService = service as IServiceWithType;
            if (typedService == null)
            {
                return Enumerable.Empty<IComponentRegistration>();
            }
            if (!(typedService.ServiceType.IsGenericType && typedService.ServiceType.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                return Enumerable.Empty<IComponentRegistration>();
            }
            Type elementType = typedService.ServiceType.GetGenericArguments()[0];
            Service elementService = typedService.ChangeType(elementType);
            Type collectionType = typeof(List<>).MakeGenericType(elementType);
            IComponentRegistration registration = RegistrationBuilder.ForDelegate(collectionType, (c, p) =>
            {
                IEnumerable<IComponentRegistration> registrations = c.ComponentRegistry.RegistrationsFor(elementService);
                IEnumerable<Object> elements = registrations.Select(cr => c.ResolveComponent(cr, p));
                // get distinct elements by type
                Array array = elements.GroupBy(o => o.GetType()).Select(o => o.First()).ToArray();
                Array array2 = Array.CreateInstance(elementType, array.Length);
                array.CopyTo(array2, 0);
                Object collection = Activator.CreateInstance(collectionType, new Object[] { array2 });
                return collection;
            }).As(service)
              .CreateRegistration();
            return new IComponentRegistration[] { registration };
        }
    }
