    public interface IUserService
    {
        User GetAll();
        User GetAll(string OrderBy);
    }
    public abstract class EntityService<T>
    {
        public T GetAll()
        {
            //Implementetion
        }
    }
    public class UserService : EntityService<User>, IUserService
    {
        public User GetAll(string OrderBy) 
        {
           //Implemenatation
        }
    }
