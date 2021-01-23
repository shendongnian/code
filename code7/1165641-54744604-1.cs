public interface IService {
  HasUserPermission(int32 userIdAuthenticated, int targetId));}
public interface ISchoolyearService : IService {
  /* Include all other methods except for HasUserPermission */
}
- In UserActionsAuthorizationFilter, add a field: "internal IService ServiceProvider"
- In UserActionsAuthorizationFilter, modify IsResourceOwner():
from
var service = (ISchoolyearService)requstScope.GetService(typeof(ISchoolyearService));
 to
var service = (IService)requstScope.GetService(this.ServiceProvider);
- Then, change all the attributes on your Controllers to specify which type of IService they use
[UserActionsAuthorizationFilter(ServiceProvider = typeof(ISchoolyearService))] <br> internal SchoolyearController : Controller { }
The notable drawback of this approach is that you're then committed to only allowing users to access a resource if they pass the `HasUserPermission()` check, so this way you're barred from making any deeper URLs that should be publically accessible, like `/api/testresults/3/public`
P.S> You are right that it's ridiculous to figure out which SQL table to check based on the controller name 
