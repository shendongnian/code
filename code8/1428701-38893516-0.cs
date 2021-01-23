        static bool SearchAndReplace (List<string> strings, string valueToSearch, string newValue)
        {
            var found = strings.Select ((s,i)=> new{index=i, val=s}).FirstOrDefault(x=>x.val==valueToSearch);
            if (found != null)
            {
                strings [found.index] = newValue;
                return true;
            }
            return false;
        }
        
        static bool SearchAndReplace (List<List<string>> stringsList, string valueToSearch, string newValue)
        {
            foreach (var strings in stringsList)
            {
                if (SearchAndReplace(strings, valueToSearch, newValue))
                    return true;
            }
            return false;
                
        }
