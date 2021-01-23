                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain, username, password))
                {
                    //PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain, username, password);
                    UserPrincipal up = new UserPrincipal(pc);
                    up.SetPassword(newPassword);
                }
