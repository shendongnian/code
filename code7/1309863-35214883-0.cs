    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool foundUser = false;
            List<string> roles = new List<string>();
            roles.Add("GeneralUser");
            // this will call the default MembershipProvider
            if (Membership.Provider.ValidateUser(LoginBox.UserName, LoginBox.Password))
            {
                foundUser = true;
                // do any additional lookups for this type of user (Default MembershipProvider) here
            } // otherwise, explicitly call secondary provider
            else if (
                Membership.Providers["SecondarySqlMembershipProvider"].ValidateUser(LoginBox.UserName,
                                                                                    LoginBox.Password))
            {
                foundUser = true;
                roles.Add("SecondaryUser");
                // do any additional lookups relevant to this type of user
            }
            if (foundUser)
            {
                Session["UserId"] = LoginBox.UserName;
                Session["Groups"] = roles;
            }
            e.Authenticated = foundUser;
        }
