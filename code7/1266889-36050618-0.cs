    // search group name ;
            List<IGroup> foundGroups = null;
            try
            {
                foundGroups = activeDirectoryClient.Groups
                              .ExecuteAsync().Result.CurrentPage.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError getting Group {0} {1}",
                    e.Message, e.InnerException != null ? e.InnerException.Message : "");
            }
            if (foundGroups != null && foundGroups.Count > 0)
            {
                foreach(IGroup grouplist in foundGroups)
                {
                    Console.WriteLine("Group DisplayName:{0}", grouplist.DisplayName);
                }
            }
            else
            {
                Console.WriteLine("Group Not Found");
            }
