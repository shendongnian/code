    public class UserRepository
    {
        private readonly IDbConnection _connection;
        private UserMapper _mapper = new UserMapper();
        public IReadOnlyList<User> GetAllUsers()
        {
            using (var cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, UserName FROM Users";
                return cmd.ToList<User>(_mapper);
            }
        }
    }
