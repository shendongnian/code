    using System.DirectoryServices.AccountManagement;
    
    // create a machine-context (local machine)
    PrincipalContext ctx = new PrincipalContext( ContextType.Machine );
    UserPrincipal user =
        UserPrincipal.Current;
        // Or use `FindByIdentity` if you want to manually specify a user.
        // UserPrincipal.FindByIdentity( ctx, IdentityType.Sid, <YourSidHere> );
    if( user != null ) {
        
        Console.WriteLine("Password expires: {0}", !user.PasswordNeverExpires );
    }
