    class TestRepo
    {
        public void Add<T>(T myType)
        {
            //add to an in-memory "database"
        }
        public IEnumerable<T> Get<T>(Expression<Func<T, bool>> filter)
        {
            return inMemoryDataBase.Where(filter);
        }
    }
