    public interface IUserHelperMethods
    {
        // Empty marker interface
    }
    public static class UserHelperExtensions
    {
        public static ClaimsPrincipal GetCurrentUser(this IUserHelperMethods)
        {
            return HttpContext.Current.User as ClaimsPrincipal;
        }
    }
    public class ApiControllerBase : ApiController, IUserHelperMethods
    {
        public void Foo()
        {
            this.GetCurrentUser();
        }
    }
    public class AuthorizeAttributeTotalAccess : AuthorizeAttributeBase, IUserHelperMethods
    {
        public void Foo()
        {
            this.GetCurrentUser();
        }
    }
