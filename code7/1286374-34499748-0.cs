    public class UserController : DefaultController<User>
    {
        public UserController()
            : base (new GreatStrategy<User>(new Repository<User>()))
        {
            //GreatStrategy extends BaseStrategy...
        }
        
    }
