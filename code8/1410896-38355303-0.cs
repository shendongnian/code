    public class MyController : MyController
    {
        private readonly IRepository _repo;
        public MyController(IRepository repo)
        {
            _repo = repo;
        }
        public IActionResult GetData(string userId)
        {
            var data = _repo.GetUserInformation(userId);
            var someTransformation = null; // transform data
            return View(someTransformation);
        }
    }
    public interface IRepository
    {
        MyObject GetData(string userId);
    }
    public class Repository : IRepository
    {
        private readonly IDbContext _iDbContext;
        public Repository(IDbContext iDbContext)
        {
            _iDbContext = iDbContext;
        }
        public MyObject GetUserInformation(string userId)
        {
            return _iDbContext.MyObjects.Where(w => w.UserId == userId);
        }
    }
    public interface IDbContext
    {
        // impl
    }
    public class DbContext : IDbContext
    {
        // impl
    }
