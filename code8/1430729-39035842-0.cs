    public DirectoryEntry GetUser(string username)
        {
            try
            {
                Forest currentForest = Forest.GetCurrentForest();
                GlobalCatalog gc = currentForest.FindGlobalCatalog();
                using (DirectorySearcher searcher = gc.GetDirectorySearcher())
                {
                    searcher.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(samaccountname=" + username + "*))";
                    SearchResult results = searcher.FindOne();
                    if (!(results == null))
                    {
                        DirectoryEntry de = new DirectoryEntry(results.Path, strAdminUser, strAdminPass, AuthenticationTypes.Secure);
                        de = new DirectoryEntry(results.Path);
                        de.Path = results.Path.Replace("GC://DCNAME.", "LDAP://");
                        de.CommitChanges();
                        //System.Windows.Forms.MessageBox.Show(de.Path);
                        return de;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (DirectoryServicesCOMException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }
