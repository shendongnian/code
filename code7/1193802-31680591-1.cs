    public abstract class AbstractMapper<T> where T : AbstractObject
    {
         protected abstract T doLoad(T obj);
    }
    
    public class UserMapper : AbstractMapper<User>
    {
         protected override User doLoad(User obj)
         {
             ...
         } 
    }
