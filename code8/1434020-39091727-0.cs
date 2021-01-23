    public class TestService : BaseService
    {
        private BrowseService _browseService;
        public TestService(BrowseService browseService)
        {
            _browseService = browseService;
        }
        public string DoStuff(string username)
        {
            return _browseService.DoStuff(username);
        }
    }
    public class BaseService { }
    public abstract class BrowseService
    {
        public abstract string DoStuff(string username);
    }
    public class MyBrowseService : BrowseService
    {
        public override string DoStuff(string username)
        {
            return string.Format("MyBrowseService.DoStuff is invoked with value={0}", username);
        }
    }
