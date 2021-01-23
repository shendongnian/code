        public override Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser)
         {
                    var claims = new List<Claim>()
                    {
                       new Claim("Id", this.UserName),
                       new Claim("BackEndId", this.UserName)
                    };
                    this.AuthenticationManager.User.AddIdentity(new ClaimsIdentity(claims));
                    return base.SignInAsync(user, isPersistent, rememberBrowser);
        }
    
     
    
        
    
