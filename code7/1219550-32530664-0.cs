    	        List<IUser> usersList = null;
                IPagedCollection<IUser> searchResults = null;
                try
                {
                    IUserCollection userCollection = activeDirectoryClient.Users;
                    userResult = userCollection.ExecuteAsync().Result;
                    usersList = searchResults.CurrentPage.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nError getting User {0} {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }
                if (usersList != null && usersList.Count > 0)
                {
                    do
                    {
                        usersList = searchResults.CurrentPage.ToList();
                        foreach (IUser user in usersList)
                        {
                            Console.WriteLine("User DisplayName: {0}  UPN: {1}  Manager: {2}",
                                user.DisplayName, user.UserPrincipalName, user.Manager);
                        }
                        searchResults = searchResults.GetNextPageAsync().Result;
                    } while (searchResults != null);
                }
                else
                {
                    Console.WriteLine("No users found");
                }
