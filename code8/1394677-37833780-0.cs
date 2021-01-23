    public class Foo
    {
        private readonly IDbConnection _dbConnection;
        public Foo(IDbConnection dbConnection)
        {
            if (dbConnection == null)
                throw new ArgumentNullException(nameof(dbConnection));
            _dbConnection = dbConnection;
        }
        public Whatever Get()
        {
            var thingyRaw = _dbConnection.GetStuff();
            var thingy = null; // pretend some transformation occurred on thingyRaw to get thingy
            return thingy;
        }
    }
    
