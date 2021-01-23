    public class UsersController : Controller
    {
       private IUsersRepository UsersRepository { get; }
   
        public UsersController(IUsersRepository usersRepository)
        {
            UsersRepository = usersRepository;
        }
        public UsersController():this(DependencyResolver.Current.GetService(typeof(IUsersRepository)) as IUsersRepository)
        {
        
        }
        public ActionResult Index ()
        {
           MyUserDefinedModel data = UsersRepository.MyRepository();
           return View(data);
        }
}
