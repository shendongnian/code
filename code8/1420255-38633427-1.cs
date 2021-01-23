    // Interface for entities that only contains id.
    public interface IIdentifiableEntity
    {
        int Id { get; }
    }
    
    public interface INotificationService
    {
       void Notify(User user, IIdentifiableEntity entity);
    }
    
    public interface IAuthorizationService
    {
       void IsAuthorized(User user);
    }
    
    public interface IPersistenceService
    {
       // Return the entity as a interface here...
       IIdentifiableEntity AddSomeEntity(SomeModel model);
       void SaveChanges();
    }
    
    public interface ISomeModelManagementService
    {
       void AddSomeModelAndNotify(User user, SomeModel model);
    }
    
    public class SomeModelManagementService : ISomeModelManagementService
    {
       //Here would be constructor injection of INotificationService, IAuthorizationService and IPersistenceService
    
       void AddSomeModelAndNotify(User user, SomeModel model)
       {
          if(authorizationService.IsAuthorized(user))
          {
             IIdentifiableEntity entity = persistenceService.AddSomeEntity(model);
             persistenceService.SaveChanges();
             // Pass reference entity to Notify.
             notificationService.Notify(user,entity);
          }
          else
          {
             throw new UnauthorizedException();
          }
       }
    }
