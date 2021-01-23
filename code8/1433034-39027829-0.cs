    public class UserRepository : IUserRepository,
                         RepositoryBase
    {
        public UserRepository(string connectionString)
         : base(connectionString)
        {
        }
    }
