    public static IEnumerable<SearchResult> DirectMembers(string nameOfMyBigGroup)
    {
        var namePrefixes = "abcdefghijklmnopqrstuvwxyz".Select(c=>c.ToString());
        foreach(var namePrefix in namePrefixes) 
        {
            searcher.Filter = "(&(sAMAccountName=" + namePrefix + "*)(memberOf=" + nameOfMyBigGroup + "))";
            string[] properties = new string[]
                {
                    "givenName",
                    "sn",
                    "displayName",
                    "mail",
                    "physicalDeliveryOfficeName",
                    "division",
                    "grpDivision"
                };
            searcher.PropertiesToLoad.AddRange(properties);
            var results = searcher.FindAll();
            foreach (var result in results) yield return result;
        }
    }
