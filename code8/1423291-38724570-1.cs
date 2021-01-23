    public class MyService
    {
        private IRepository<Something, SomethingElse> _repo;
        public MyService(IRepository<Something, SomethingElse> repo)
        {
            // Container will actually give us MyRepository<Something, SomethingElse>
            _repo = repo;
        }
    }
