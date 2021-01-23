    public void UserMapper  : IEntityMapper
    {
        public void Map(IDataRecord record)
        {
            var user = new User();
              
            //requires that you specify columns in your SELECT query
            //to not break the mapper in future versions.
            user.FirstName = record[0]
        }
    }
