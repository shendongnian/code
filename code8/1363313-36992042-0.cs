    public async Task<string> CreateUser(string username, string password)
        {
            string jwt = String.Empty;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) // user doesn't exist, create user
            {
                var newUser = await _userManager.CreateAsync(new ApplicationUser() { UserName = username }, password); 
                if (newUser.Succeeded) //user was successfully created, sign in user
                {
                    user = await _userManager.FindByNameAsync(username);
                    var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, true);
                    if (signInResult.Succeeded) //user signed in, create a JWT
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();
                        List<Claim> userClaims = new List<Claim>();
                        
                        //add any claims to the userClaims collection that you want to be part of the JWT
                        //...
                        ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user.UserName, "TokenAuth"), userClaims);
                        DateTime expires = DateTime.Now.AddMinutes(30); //or whatever
                        var securityToken = tokenHandler.CreateToken(
                            issuer: _tokenOptions.Issuer,  //_tokenAuthOptions is a class that holds the issuer, audience, and RSA security key
                            audience: _tokenOptions.Audience,
                            subject: identity,
                            notBefore: DateTime.Now,
                            expires: expires,
                            signingCredentials: _tokenOptions.SigningCredentials
                            );
                        jwt = tokenHandler.WriteToken(securityToken);
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        await _signInManager.SignOutAsync(); //sign the user out, which deletes the cookie that gets added if you are using Identity.  It's not needed as security is based on the JWT
                    }
                }
                //handle other cases...
            }
        }
