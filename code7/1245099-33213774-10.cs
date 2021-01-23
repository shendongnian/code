    public class UserRepository
    {
        private readonly IDbConnection _connection;
        private UserMapper _mapper = new UserMapper();
        public IReadOnlyList<User> GetAllUsers()
        {
            using (var cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, UserName FROM Users";
                using (var reader = cmd.ExecuteReader())
                {
                    var users = new List<User>();
                    while (reader.Read())
                    {
                       var user = _mapper.Map(reader);
                       users.Add(user);
                    }
                    return users;
                }
            }
        }
    }
