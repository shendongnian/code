      UserPrincipal newUser = new UserPrincipal(principalContext);
                newUser.Name = userId;
                newUser.UserPrincipalName = userId;
                newUser.Save();
                newUser.Enabled = false;
                newUser.SetPassword(pwd.ToString());
                newUser.Save();
