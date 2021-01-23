    public static void searchDeletedUsers()
    {
       using (DirectoryEntry entry = new DirectoryEntry("LDAP://yourldappath.com"))
       {
          using (DirectorySearcher searcher = new DirectorySearcher(entry))
          {
             searcher.Filter = "(&(isDeleted=TRUE)(objectclass=user))";
             searcher.Tombstone = true;
             var users = searcher.FindAll();
             foreach(var user in users)
             {
                //user will contain the deleted user object
             }
          }
       }
    }
