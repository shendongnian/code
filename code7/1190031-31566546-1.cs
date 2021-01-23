        public static void ImpersonateByEMail(string email, HttpRequestBase request)
        {
            // you don't need this if clause, or you introduce this appsetting in your web.config
            if ("true" == ConfigurationManager.AppSettings["EnableImpersonate"])
            {
                var impersonatedIdentity = new ClaimsIdentity("ApplicationCookie");
                impersonatedIdentity.AddClaim(new Claim(ClaimTypes.Email, email));
                // Add other claims you might need
                var owinContext = request.GetOwinContext();
                owinContext.Authentication.SignOut("ApplicationCookie");
                owinContext.Authentication.SignIn(impersonatedIdentity);
            }
        }
