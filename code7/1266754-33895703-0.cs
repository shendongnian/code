    var param = { "email": "ex.ample@email.com" };
    $.ajax({
        url: "/api/users/" + param.email,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data == true) {
                // notify user that email exists
            }
            else {
                // not taken
            }             
        }                      
    });
    
    [HttpGet, Route("api/users/{emailaddress}")]
    public bool Get(string emailaddress)
    {
        string email = emailaddress;
        UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>();
        ApplicationUserManager<ApplicationUser> manager = new ApplicationUserManager<ApplicationUser>(userStore);
        ApplicationUser user = manager.FindByEmail(email);
    
        if (user != null)
        {
            return true;
        }
    
        else
        {
            return false;
        }
    }
    
    //helper class:
    public class UserResponse
    {
        public string email { get; set; }
    }
