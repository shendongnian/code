	public class DatabaseWrapper : IDisposable
	{
		// Fields.
		private readonly SQLiteConnection Connection;
		private readonly object Lock = new object();
		public DatabaseWrapper(string databasePath)
		{
			if (string.IsNullOrEmpty(databasePath)) throw new ArgumentException("Database path cannot be null or empty.");
			this.Connection = new SQLiteConnection(databasePath);
		}
		public IEnumerable<T> Entities<T>() where T : new()
		{
			lock (this.Lock)
			{
				return this.Connection.Table<T>();
			}
		}
		public IEnumerable<T> Query<T>(string query, params object[] args) where T : new()
		{
			lock (this.Lock)
			{
				return this.Connection.Query<T>(query, args);
			}
		}
		public int ExecuteNonQuery(string sql, params object[] args)
		{
			lock (this.Lock)
			{
				return this.Connection.Execute(sql, args);
			}
		}
		public T ExecuteScalar<T>(string sql, params object[] args)
		{
			lock (this.Lock)
			{
				return this.Connection.ExecuteScalar<T>(sql, args);
			}
		}
		public void Insert<T>(T entity)
		{
			lock (this.Lock)
			{
				this.Connection.Insert(entity);
			}
		}
		public void Update<T>(T entity)
		{
			lock (this.Lock)
			{
				this.Connection.Update(entity);
			}
		}
		public void Upsert<T>(T entity)
		{
			lock (this.Lock)
			{
				var rowCount = this.Connection.Update(entity);
				if (rowCount == 0)
				{
					this.Connection.Insert(entity);
				}
			}
		}
		public void Delete<T>(T entity)
		{
			lock (this.Lock)
			{
				this.Connection.Delete(entity);
			}
		}
        public void Dispose()
        {
            this.Connection.Dispose();
        }
	}
