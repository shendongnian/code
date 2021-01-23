    public static void DoStuff(UserPrincipal princ) {
            
            var allDomains = Forest.GetCurrentForest().Domains.Cast<Domain>();
    
            var allSearcher = allDomains.Select(domain => {
              var searcher = new DirectorySearcher(new DirectoryEntry("LDAP://" + domain.Name));
              searcher.Filter = $"(&(&(objectCategory=person)(objectClass=user)(userPrincipalName=*{princ.SamAccountName}*)))";
              return searcher;
            });
    
            var directoryEntriesFound =
              allSearcher.SelectMany(searcher =>
                searcher.FindAll()
                  .Cast<SearchResult>()
                  .Select(result => result.GetDirectoryEntry()));
    
            var memberOf = directoryEntriesFound.Select(entry => {
              using (entry) {
                return new {
                  Name = entry.Name,
                  GroupName = ((object[])entry.Properties["MemberOf"].Value)
                    .Select(obj => obj.ToString())
                };
              }
            }
              );
    
            var result1 = new List<string>();
            foreach (var member in memberOf) {
              if(member.GroupName.Contains("Student") )
                Console.WriteLine(princ.SamAccountName + " is Student");
              if (member.GroupName.Contains("Employee"))
                Console.WriteLine(princ.SamAccountName + " is Employee");
    
            }
    
           
          }
