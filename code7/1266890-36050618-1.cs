      var searchString = "upnname";
            try
            {
                IUserFetcher userfetch;
                List<IUser> users = activeDirectoryClient.Users.Where(User => User.UserPrincipalName.StartsWith(searchString)).ExecuteAsync().Result.CurrentPage.ToList();
                foreach (IUser user in users)
                {
                    userfetch = user as IUserFetcher;
                    IList<Group> groupMembership = new List<Group>();
                    IPagedCollection<IDirectoryObject> pagedCollection =userfetch.MemberOf.ExecuteAsync().Result;
                    List<IDirectoryObject> directoryObjects = pagedCollection.CurrentPage.ToList();
                    foreach (IDirectoryObject directoryObject in directoryObjects)
                    {
                        if (directoryObject is Group)
                        {
                            var group = directoryObject as Group;
                             if(group.SecurityEnabled.Equals(true))
                            {
                            groupMembership.Add(group);
                            Console.WriteLine("UserPrincinpleName:{0} Group DisplayName:{1}", user.UserPrincipalName, group.DisplayName);
                            }
                        }
                    }
                }          
                   }
               
            catch (Exception e)
            {
                Console.WriteLine("\nError getting Group {0} {1}",
                    e.Message, e.InnerException != null ? e.InnerException.Message : "");
            }
