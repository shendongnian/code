        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                // just grab the username without domain info
                string[] arrTmp = HttpContext.Current.User.Identity.Name.Split('\\');
                string username = arrTmp[arrTmp.Length - 1];
                // Create an array of role names
                ArrayList arrlstRoles = new ArrayList();
                // work-around
                if (username == "fakename")
                    arrlstRoles.Add("Admin");
                //Convert the roleList ArrayList to a String array
                string[] arrRoles = (string[])arrlstRoles.ToArray(typeof(String));
                // Add the roles to the User Principal
                HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(User.Identity, arrRoles);
            }
        }
