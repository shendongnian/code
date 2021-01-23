    public interface IUserService
    {
        string[] GetUsers();
    }
    
    public class UserService : IUserService
    {
        public string[] GetUsers()
        {
            return new string[] { "value1", "value2" };
        }
    }
