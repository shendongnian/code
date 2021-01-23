    using(var context = new PrincipalContext(ContextType.Domain, "TRY.LOCAL", "DC=TRY,DC=LOCAL","administrator","password"))
            {
                using(var search = new PrincipalSearcher(new UserPrincipal (context))){
                    UserPrincipal usr = new UserPrincipal(context);
                    PrincipalSearcher searcher = new PrincipalSearcher(usr);
                    foreach(var result in searcher.FindAll()){
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        string user_id = Convert.ToString(de.Properties["samaccountname"].Value);
                        Console.WriteLine(user_id);
                        if (user_id == "palani"){
                        	Console.WriteLine("Checked");
                            var wi = new WindowsIdentity(user_id);
                            var wp = new WindowsPrincipal(wi);
                            Console.WriteLine(wp.Identity);
                            if(wp.IsInRole("Administrators")){
                                Console.WriteLine("Administrators\n\n");
                            }
                            else{
                                Console.WriteLine("Users\n\n");
                            }
                        }
                    }
            }
        }
