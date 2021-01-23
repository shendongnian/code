    using System.Security.Principal;
    
    namespace MyApp.Entensions
    {
         public static class Permissions
         {
             public bool CanEditItems(this IPrinciple user)
             {
                return user.IsInAnyRole("Manager", "Admin"); 
             }
    
            public bool CanDeleteItems(this IPrinciple user)
            {
               return user.IsInAnyRole("Admin"); 
            }
    
            // Other permissions
    
         }
     }
