            Dictionary<char, int> countDictionary = new Dictionary<char, int>();
            
            foreach (var c in input.ToLower())
            {
                if (!countDictionary.ContainsKey(c))
                {
                    countDictionary.Add(c, 0);
                }
                countDictionary[c]++;
            }
