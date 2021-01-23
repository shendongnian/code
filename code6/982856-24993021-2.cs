    public class MyService
    {
        private IMyDbRepository _repos;
        
        public MyService(IMyDbRepository dbRepos)
        {
            _repos = dbRepos;
        }
    
        public string[] GetClientNames()
        {
            return _repos.GetAllClients().Where(c=>!c.IsDisabled).OrderBy(c=>c.Name).ToArray();
        }
    }
