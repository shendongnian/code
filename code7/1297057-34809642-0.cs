        // Set a variable to your SQLiteAsyncConnection
        database = sqlLite.GetAsyncConnection();
        // Call a query and have it map back to the object type
        public async Task<List<T>> QueryAsync<T>(string queryText, params Object[] args) where T : class, new()
        {
            return await database.QueryAsync<T>(queryText, args);
        }
        // Or here is another helper function
        public async Task<List<T>> GetAllAsync<T>() where T : class, new()
        {
            return await database.Table<T>().ToListAsync();           
        }
