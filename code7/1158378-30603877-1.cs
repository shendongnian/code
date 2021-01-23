    // NOTE: Do not let IUserRepository implement IDisposable. This violates
    // the Dependency Inversion Principle.
    // NOTE2: It's very unlikely that UserRepository itself needs any disposal.
    public class UserRepository : IUserRepository
    {
        // This is Identity UserManager
        private readonly IAuthenticationManager _authenticationManager;
         public UserRepository(IAuthenticationManager authenticationManager)
         {
              _authenticationManager = authenticationManager;
         }
         public void Delete(AppUser user) {
             // Here we create and dispose the UserManager during the execution
             // of this method.
             using (manager = new UserManager<AppUser, string>(
                 new UserStore<AppUser>())) {
                 manager.DeleteAsync(user).Result;
             }
         }
    }
