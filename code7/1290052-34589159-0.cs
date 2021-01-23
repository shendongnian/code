    using Microsoft.AspNet.Identity;
    using System.Web;
    public class MyClass()
    {
        public void MyMethod()
        {
            // Get the current context
            var httpContext = HttpContext.Current;
   
            // Get the user id
            var userId = httpContext.User.Identity.GetUserId();
        }
    }
