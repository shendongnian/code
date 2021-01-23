    if (!IsPostBack)
                {
                    user = Membership.GetUser(Page.User.Identity.Name);
                    user_txt.Text = user.UserName;
                    email_txt.Text = user.Email;
                }
