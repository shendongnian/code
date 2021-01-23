    public interface IEntityMapper
    {
       object Map(IDataRecord record);
    }
    
    public void UserMapper  : IEntityMapper
    {
        public void Map(IDataRecord record)
        {
            var user = new User();
            user.FirstName = record["firstName"]
        }
    }
