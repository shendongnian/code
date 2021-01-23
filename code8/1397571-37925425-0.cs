    public class DbContext<T> : DbContext
    {
        public static IEnumerable<T> GetAll()
        {
            var sql = "SELECT * FROM " + TableName();
            return DB().Fetch<T> (sql);
        }
    }
