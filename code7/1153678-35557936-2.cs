        public class InMemoryDatabase
        {
            private readonly OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(":memory:", SqliteOrmLiteDialectProvider.Instance);
            public IDbConnection OpenConnection() => this.dbFactory.OpenDbConnection();
            public void Insert<T>(IEnumerable<T> items)
            {
                using (var db = this.OpenConnection())
                {
                    db.CreateTableIfNotExists<T>();
                    foreach (var item in items)
                    {
                        db.Insert(item);
                    }
                }
            }
        }
