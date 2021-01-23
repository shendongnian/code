            private void IdentitySignIn(int userId, string userLogin)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.PrimarySid, userId.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, userLogin));
    
                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
    
                authenticationManager.SignIn(new AuthenticationProperties()
                    {
                        ExpiresUtc = DateTime.UtcNow.AddDays(200),
                        IsPersistent = true
                    }, identity);
            }
