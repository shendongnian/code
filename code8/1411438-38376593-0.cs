     myUserList AppUsers = new myUserList();    
     using (PrincipalContext pcxt = new PrincipalContext(ContextType.Domain,  "my-global-catalogue-server.subdomain.domain.com:port", "DC=subdomain,DC=domain,DC=com"))
                {
                    UserPrincipal User = new UserPrincipal(pcxt);
                    User.EmailAddress = emailString;
    
                    PrincipalSearcher srch = new PrincipalSearcher(User);
                    foreach (var principal in srch.FindAll())
                    {
                        var p = (UserPrincipal)principal;
                        myUserRow User = AppUsers.NewUsersRow();
                        User.FirstName = p.GivenName;
                        User.LastName = p.Surname;
                        User.Email = p.EmailAddress;
                        AppUsers.AddUsersRow(User);
    
                    }
                }
