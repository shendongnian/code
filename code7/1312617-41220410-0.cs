     public class ResourceOwnerPasswordValidator: IResourceOwnerPasswordValidator
     {
        private MyUserManager _myUserManager { get; set; }
        public ResourceOwnerPasswordValidator()
        {
            _myUserManager = new MyUserManager();
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _myUserManager.FindByNameAsync(context.UserName);
            if (user != null && await _myUserManager.CheckPasswordAsync(user,context.Password))
            {
                 context.Result = new GrantValidationResult(
                     subject: "2", 
                     authenticationMethod: "custom", 
                     claims: someClaimsList);
                return;
            }
            context.Result = new GrantValidationResult(
                        TokenRequestErrors.InvalidGrant,
                        "invalid custom credential");
        }
      
    }
