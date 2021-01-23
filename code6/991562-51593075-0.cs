      using (var context = new PrincipalContext(ContextType.Domain, "xyz.com", "Administrator", "xyz123"))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                 foreach (var result in searcher.FindAll())
                    {
                      DirectoryEntry de = result.GetUnderlyingObject() as DrectoryEntry;
                 foreach (String key in de.Properties.PropertyNames)
                    {
                       Console.WriteLine(key + " : " + de.Properties[key].Value);
                    }
                   Console.WriteLine("Enabled: "	+((System.DirectoryServices.AccountManagement.AuthenticablePrincipal)(result)).Enabled);
                   Console.WriteLine("First Name: " + de.Properties["givenName"].Value);
                        }
                     }
                 }
            Console.ReadLine();
