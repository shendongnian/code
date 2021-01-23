    UserPrincipal up = new UserPrincipal(oPrincipalContext);                        
                    up.SamAccountName = userId;
                    up.SetPassword(System.Web.Security.Membership.GeneratePassword(minPwdLength,
                                       pwdProperties));                        
                    up.Enabled = true;
                    up.ExpirePasswordNow();    
                    up.Save();
