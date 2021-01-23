    interface IUserManagerWrapper 
    {
         roles GetRoles ();
    }
    
    public class MyUserManager : IUserManagerWrapper 
    {
          GetRoles () 
        {
             return UserManager.GetRoles()
        }
    }
