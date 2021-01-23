    public class UserService : IUserService {
	   private ContextFactory _ContextFactory;
	
	   public UserService(ContextFactory contextFactory) {
		   _ContextFactory = contextFactory;
	   }
	
       public void AddUser(UserModel userModel) {
           ...
		   using (var context = _ContextFactory.CreateInstance()) {
			   context.Users.Add(user);
		   }
       }
