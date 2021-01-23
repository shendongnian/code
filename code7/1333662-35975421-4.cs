    public class UserService
    {
       IMessageDispatcher _dispatcher;
    
       public UserService(IMessageDispatcher dispatcher)
       {
           _dispatcher = dispatcher;
       }
    
       public void Create(User user)
       {
           //[...]
    
    
           _dispatcher.Dispatch(new UserCreated(user.Id));
       }
    }
