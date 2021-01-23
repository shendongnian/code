    using (var context = new PrincipalContext(ContextType.Domain, "TRY.local"))
    {
        using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
        {
            foreach (var result in searcher.FindAll())
            {
                DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                string path = de.Path;
                var offset = path.IndexOf('/');
				offset = path.IndexOf('/', offset+1);
				offset = path.IndexOf('/', offset+1);
				path = path.Substring(offset+1);
                string user_id = Convert.ToString(de.Properties["samaccountname"].Value); 
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain,
					                       "TRY.local",
					                       path,
					                       "administrator",
					                       "password");
