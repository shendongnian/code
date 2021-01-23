    // no locks here, all callers to lock
    public class FOO {
       public Guid UniqueIdentifier {get;set;}
       public string UserName {get;set;}
    }
    // in caller code
    usersLock = new object();
    List<FOO> users = ...
    
    lock(usersLock) 
    {
        // modify/read users here.
        ...
    }
