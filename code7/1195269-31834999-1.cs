    public class ExternalAuthenticationController : Controller
            {
    
                public ActionResult Index()
                {
                    return View();
                }
               
                public ActionResult Login(string id, string hash, string login)
                {
                   // Create the combine string
                   string data = //user id + same stuff than in A;
                   // Create the hash of the combine string
                   HashAlgorithm algorithm = MD5.Create();
                   byte[] hashArray =    algorithm.ComputeHash(Encoding.UTF8.GetBytes(data));
                   StringBuilder sb = new StringBuilder();
                   foreach (byte b in hashArray)
                      sb.Append(b.ToString("X2"));
                   string originalHash = sb.ToString();
                   // Compare the two hash. If they are the same, create the variable
                   if (hash.CompareTo(originalHash) == 0)
                   {
                
                   if (System.Web.HttpContext.Current.Application["Auth"] == null)
                   {
                       System.Web.HttpContext.Current.Application["Auth"] = false;
                   }
                   if (Convert.ToBoolean(login))
                   {
                       System.Web.HttpContext.Current.Application["Auth"] = true;
                   }
                  else
                  {
                      System.Web.HttpContext.Current.Application["Auth"] = false;
                  }
                 }
             }
