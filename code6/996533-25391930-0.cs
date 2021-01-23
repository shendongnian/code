    public interface IHandleCrudOperations<T>
    {
        void Remove(T item);
        void Add(T item);
        void Edit(T item);
        void Clone(T item);
    }
    
    public class UserRepository : IHandleCrudOperations<int>
    {
    	public void Remove(int userKey)
    	{
    		_context.Users.FirstOrDefault(x => x.UserKey == userKey);
    		//stuff
    	}
    }
