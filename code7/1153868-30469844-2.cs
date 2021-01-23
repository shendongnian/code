    public class ApplicationSignInManager : SignInManager<User, int>
    {    
     
         public override async Task SignInAsync(User user, bool isPersistent, bool rememberBrowser)
         {
             if (!user.isDeleted)
             {
                 await base.SignInAsync(user, isPersistent, rememberBrowser);
             } 
             else
             {
                 ...
             }                      
         }
    }
