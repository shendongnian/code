    public class MyAuthentication : Controller
    {
      public MyAuthentication()
        {
            isAuthenticated();
        }  
        private void isAuthenticated()
        {
          // do your authentication
          
          //if user authenticated keep user details within a cookie, so that 
          // when the next request, program logic will search for cookie, 
          //if it is found then assume user was authenticated else redirect to login page.
 
        }
    }
