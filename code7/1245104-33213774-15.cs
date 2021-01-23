    public class UserRepository
    {
        private readonly IDbConnection _connection;
        private UserMapper _mapper = new UserMapper();
        public IReadOnlyList<User> GetAllUsers()
        {
            using (var cmd = _connection.CreateCommand())
            {
                cmd.CommandText = @"SELECT Id, UserName, Address.City as Address_City 
                                    FROM Users 
                                    JOIN Address ON (Address.Id = Users.AddressId)";
                return cmd.ToList<User>(_mapper);
            }
        }
    }
