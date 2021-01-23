    public class CovariantHandleEventRegistrationSource : IRegistrationSource
    {
      public bool IsAdapterForIndividualComponents
      {
        get
        {
          return false;
        }
      }
      public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, 
                                    Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
      {
        IServiceWithType typedService = service as IServiceWithType;
        if (typedService == null)
        {
          yield break;
        }
        if (typedService.ServiceType.IsGenericType && typedService.ServiceType.GetGenericTypeDefinition() == typeof(IHandleEvent<>))
        {
          IEnumerable<IComponentRegistration> eventRegistrations = registrationAccessor(new TypedService(typeof(IEvent)));
          foreach (IComponentRegistration eventRegistration in eventRegistrations)
          {
            Type handleEventType = typeof(IHandleEvent<>).MakeGenericType(eventRegistration.Activator.LimitType);
            IComponentRegistration handleEventRegistration = RegistrationBuilder.ForDelegate((c, p) => c.Resolve(handleEventType, p))
                                              .As(service)
                                              .CreateRegistration();
            yield return handleEventRegistration;
          }
        }
      }
    }
