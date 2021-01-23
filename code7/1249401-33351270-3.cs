    public class LoginController : Controller
    {
      public ActionResult Login(string userName, string password)
      {
         // ... validate user logs to site 1 etc
         var site2UserName = userName;
         var token = new Token { UserName = site2UserName };
         var serializer = new DataContractJsonSerializer(typeof(Token));
         string decryptedToken;
         using (var stream = new MemoryStream())
         {
           serializer.WriteObject(stream, token);
           decryptedToken = Encoding.UTF8.GetString(stream.ToArray());
         }
         // symmetrical encryption
         return new View(new LoginMode { Token = HttpUtility.UrlEncode(Encrypt(decryptedToken)) });
      }
    }
    
