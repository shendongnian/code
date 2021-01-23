    protected bool Login(string userId)
        {
            System.Collections.Generic.List<string> d = Application["UsersLoggedIn"]
                as System.Collections.Generic.List<string>;
            if (d != null)
            {
                lock (d)
                {
                    if (d.Contains(userId))
                    {
                        // User is already logged in!!!
                        string userLoggedIn = Session["UserLoggedIn"] == null ? string.Empty : (string)Session["UserLoggedIn"];
                        if (userLoggedIn == user_id)
                        {
                            Session["UserLoggedIn"] = user_id;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        string userLoggedIn = Session["UserLoggedIn"] == null ? string.Empty : (string)Session["UserLoggedIn"];
                        if (userLoggedIn != user_id)
                        {
                            d.Add(userId);
                        }
                    }
                }
            }
            Session["UserLoggedIn"] = userId;
            return true;
        }
