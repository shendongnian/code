    public interface IDataAccess {
       User GetUserById(int userId);
    }
    public class SqlServerDataAccess : IDataAccess { 
       public User GetUserById(int userId) {
         // ... connect to database and retrieve user
       }
    }
