    // technical class, wraps an IRepository dummily forwarding all members to the wrapped object
    public class RepositoryWrapper : IRepository 
    {
      internal RepositoryWrapper(IRepository repository) {...}
    }
    
    // technical class for holding user related query extensions
    public sealed class UserQueriesWrapper : RepositoryWrapper {
      internal UserQueriesWrapper(IRepository repository) : base(repository) {...}  
    }
    
    public static class UserQueries {
          
     public static UserQueriesWrapper Users(this IRepository repository) {
       return new UserQueriesWrapper(repository);
     }
          
     public static IEnumerable<User> GetInRoles(this UserQueriesWrapper repository, params string[] roles) 
     {
      ...
      }
    }
    
    ...
    // now I can use it with a nicer and cleaner syntax
    var users = _repo.Users().GetInRoles("a", "b");
    ...
