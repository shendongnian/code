    public class CustomContextFactory : IDbContextFactory<AppContext>
    {
        public AppContext Create()
        {
            return new AppContext(CustomDbConnection);
        }
        
        private DbConnection CustomDbConnection
        {
            get
            {
                // here goes your code to build a DbConnection
            }
        }
    }
