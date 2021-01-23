    [MobileAppController]
    public class CustomAuthController : BaseApiController
    {
       private static bool isValidAssertion(JObject assertion)
       {
           var username = assertion["username"].Value<string>();
           var password = assertion["password"].Value<string>(); 
    
           //Validate user using FindAsync() method
           var user = await this.AppUserManager.FindAsync(username, password);
           return (user != null);
        }
    }
