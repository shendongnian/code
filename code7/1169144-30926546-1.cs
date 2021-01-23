        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                // just grab the username without domain info
                string[] arrTmp = HttpContext.Current.User.Identity.Name.Split('\\');
                string username = arrTmp[arrTmp.Length - 1];
                // Create an array of role names
                List<String> arrlstRoles = new List<String>();
                // work-around
                if (username == "fakename")
                    arrlstRoles.Add("Admin");
                // Add the roles to the User Principal
                HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(User.Identity, arrlstRoles.ToArray<String>());
            }
        }
