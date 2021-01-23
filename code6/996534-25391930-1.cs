    public interface IHandleCrudOperations<TKey, T>
    {
        void Remove(TKey item);
        void Add(T item);
        void Edit(T item);
        void Clone(T item);
    }
    
    public class UserRepository : IHandleCrudOperations<int, User>
    {
    	public void Remove(int userKey)
    	{
    		_context.Users.FirstOrDefault(x => x.UserKey == userKey);
    		//stuff
    	}
       public void Add(User user)
       {
       }
    }
