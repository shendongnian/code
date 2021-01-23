    public class MyController
    {
      private readonly IPersonRepository _repo;
      public MyController(IPersonRepository repo)
      {
        _repo = repo;
      }
      public IActionResult Index()
      {
        var person = _repo.Get();
        var model = Map<PersonVM>(person);
        return View(model);
      }
    }
