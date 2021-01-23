    var partialGroupNameMatches = 
          AllGroupsResults
              .Cast<SearchResult>()
              .Where(sr => sr.GetDirectoryEntry()
                               .Properties["GroupName"]
                               .Contains(searchString));
