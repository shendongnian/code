                string id = String.Empty;
                if (Session["StaffId"] != null)
                {
                    id = Session["StaffId"].ToString();
                }
                Session["StaffId"] = id;
                string username = String.Empty;
                if (Session["Username"] != null)
                {
                    username = Session["Username"].ToString();
                }
                Session["Username"] = username;
