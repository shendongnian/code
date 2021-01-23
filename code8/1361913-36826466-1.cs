     public class UsersController : ApiControllerBase
        {
    
            private IUser UserBusiness;
    
            public UsersController(IUser userBusiness)
            {
                UserBusiness = userBusiness;
            }
    
    
            [HttpPost]
            [AllowAnonymous]
            public DtoResultBase CreateUser(User user)
            {
                return Resolve(() =>
                {
                    UserBusiness.Create(user);
                    UserBusiness.Commit();
                    return new DtoResultBase();
                });
            }
