    public interface IUserMapper
    {
         BLL.User MapUser(DAL.User);
    }
    public class UserMapper : IUserMapper
    {
        public BLL.User MapUser(DAL.User user)
        {
             return new BLL.User
             {
                 FirstName = user.FirstName,
                 LastName = user.LastName,
                 Age = user.Age
                 // etc...
             };
        }
    }
