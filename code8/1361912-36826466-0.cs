     public class UsersController : ApiControllerBase
        {
    
    
            [HttpPost]
            [AllowAnonymous]
            public DtoResultBase CreateUser(User user)
            {
                return Resolve(() =>
                {
                    user.Create(user);
                    user.Commit();
                    return new DtoResultBase();
                });
            }
