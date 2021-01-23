	public class UsersController : Controller
	{
	   private IUsersRepository usersRepository;
	   public UsersController(IUsersRepository usersRepository)
	   {
		   this.usersRepository = usersRepository;
	   }
	   public ActionResult Index()
	   {
			return View(this.usersRepository.MyRepository());
	   }
	}
