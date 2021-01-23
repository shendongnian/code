        private static int GetNumberOfCombinations(string s)
        {
            // No need of recomputing the value if we already have
            if (cache.ContainsKey(s))
                return cache[s];
            // The following combines two conditions:
            // If length is 1, 1 combination possible
            // If length is 2, 1 combination is possible for sure, and 
            // 2nd combination is only valid if first two digits form an alphabet.
            if (s.Length <= 2)
                return int.Parse(s) <= 26 ? s.Length : s.Length - 1;
            int value = GetNumberOfCombinations(s.Substring(1));
            // If the first two digits form an alphabet,
            // Then only process those combinations
            if (int.Parse(s.Substring(0, 2)) <= 26)
                value += GetNumberOfCombinations(s.Substring(2));
            // Store in cache
            cache[s] = value;
            return value;
        }
