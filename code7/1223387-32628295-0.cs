    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    
    namespace TestAuth.Controllers
    {
    	public class UserModel
    	{
    		public string UserName { get; set; }
    		public string Password { get; set; }
    		public bool RememberMe { get; set; }
    	}
    
    	public class UserInfo
    	{
    		public string UserName { get; set; }
    	}
    
    	public class UserController : Controller
        {
            [AllowAnonymous]
            public ActionResult Login()
            {
    			var model = new UserModel() {Password = "password",UserName = "ItsMe", RememberMe = true};
    	        var serializedUser = Newtonsoft.Json.JsonConvert.SerializeObject(model);
    
    			var ticket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddHours(3), model.RememberMe, serializedUser);
    			var encryptedTicket = FormsAuthentication.Encrypt(ticket);
    			var isSsl = Request.IsSecureConnection; // if we are running in SSL mode then make the cookie secure only
    
    			var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
    			{
    				HttpOnly = true, // always set this to true!
    				Secure = isSsl,
    			};
    
    			if (model.RememberMe) // if the user needs to persist the cookie. Otherwise it is a session cookie
    				cookie.Expires = DateTime.Today.AddMonths(3); // currently hard coded to 3 months in the future
    
    			Response.Cookies.Set(cookie);
    
    			return View(); // return something
            }
    
    		[Authorize]
    		public ActionResult ShowUserName()
    		{
                return View(new UserInfo() {UserName = this.User.Identity.Name});
    		}
        }
    }
