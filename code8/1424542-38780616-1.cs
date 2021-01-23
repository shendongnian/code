        [CustomizeAttribute]
        public IQueryable<MyTable> Get()
        {
            return db.MyTable;
        }
