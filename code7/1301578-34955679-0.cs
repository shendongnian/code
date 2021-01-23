    public class HomeController : Controller
    {
    private readonly IUnitOfWorkFactoryPerCall _contextFactory;
    public HomeController(IUnitOfWorkFactoryPerCall contextFactory)
    {
        _contextFactory = contextFactory;
    }
    public IActionResult StartInBackground()
    {
        Task.Run(() =>
            {
                Thread.Sleep(3000);
                //System.ObjectDisposedException here
                var res = _contextFactory.Context.Users.FirstOrDefault(x => x.Id == 1);
            });
        return View();
    }
    }
