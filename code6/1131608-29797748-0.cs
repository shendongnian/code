    public class RegisterBusiness
    {
        // This most likely shouldn't be public or a property
        private UserManager<ApplicationUser> _userManager;
        private HttpSessionStateBase _session;
        public RegisterBusiness(UserManager<ApplicationUser> userManager,
          HttpSessionStateBase session)
        {
          _userManager = userManager;
          _session = session;
        }
    public async Task<bool> RegisterUser(RegisterModel objRegisterModel,  
      IAuthenticationManager authenticationManager)
    {
      var newuser = new ApplicationUser()
      {
      //...
      if (result.Succeeded)
      {
        _session["id"] = newuser.Id;
