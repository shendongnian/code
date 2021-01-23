        protected void Application_Start(object sender, EventArgs e)
        {
            Application["UsersLoggedIn"] = new System.Collections.Generic.List<string>();
        }
        protected void Session_End(object sender, EventArgs e)
        {
            // NOTE: you might want to call this from the .Logout() method - aswell -, to speed things up
            string userLoggedIn = Session["UserLoggedIn"] == null ? string.Empty : (string)Session["UserLoggedIn"];
            if (userLoggedIn.Length > 0)
            {
                System.Collections.Generic.List<string> d = Application["UsersLoggedIn"]
                    as System.Collections.Generic.List<string>;
                if (d != null)
                {
                    lock (d)
                    {
                        d.Remove(userLoggedIn);
                    }
                }
            }
        }
