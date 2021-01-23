            string[] names = {"dSSB", "dGEN", "dLYM", "dLUD", "dGGC", "dMAC", "dMMB"};
            Dictionary<string, Dictionary<long, int>> buildings = new Dictionary<string, Dictionary<long, int>>();
            for (int i = 0; i <= names.Length -1; i++) 
            {
                buildings[names[i]] = new Dictionary<long, int>();
                buildings[names[i]].Add(5L, 55);
            }
            //Here you can get the needed dictionary from the 'parent' dictionary by key
            var neededDictionary = buildings["dSSB"];
        
