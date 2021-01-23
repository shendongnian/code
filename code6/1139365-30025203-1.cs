    public class MyController : RepositoryBase
    {
        public List<Poco> GetPocos()
        {
            return Db.Select<Poco>();
        }
    }
