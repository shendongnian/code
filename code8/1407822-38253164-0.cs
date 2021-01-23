    var normalisedDepartments = 
       departments.GroupBy(x => Normalise(x.Key), y => y.Value)
                 .ToDictionary(x => x.Key, y => y.Sum());
    
        private static string Normalise(string key)
        {
            if (key == "Marketin")
            {
                return "Marketing";
            }
            return key;
        }
