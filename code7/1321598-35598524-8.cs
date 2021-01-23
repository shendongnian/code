    public class MockDataAccess : IDataAccess { 
       public User GetUserById(int userId) {
         return new User() { 
           Name = "pencilCake", ...
         }
       }
    }
