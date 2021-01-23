    public class TestController : ApiController
    {
        //[Authorize(Roles = "dev, user")]
        [EnumRolesAuthorise(UserRoles.Developer, UserRoles.Testers, UserRoles.PM)]
        public string Get()
        {
            throw new NotImplementedException();
        }
    }
    public class EnumRolesAuthoriseAttribute : AuthorizeAttribute
    {
        public EnumRolesAuthoriseAttribute(params UserRoles[] roles)
        {
            Roles = string.Join(",", roles.Select(r => Enum.GetName(typeof (UserRoles), r)));
        }
    }
    public enum UserRoles
    {
        Developer,
        Testers,
        PM
    }
