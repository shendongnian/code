            var input = 2;
            var dictionary = new Dictionary<int, int> { { 1, 2 }, { 3, 8 }, { 9, 1 } };
            var smallestDifference = int.MaxValue;
            var keys = new List<int>();
            if (dictionary.ContainsKey(input))
            {
                return dictionary[input];
            }
            foreach (var entry in dictionary)
            {
                var difference = entry.Key - input;
                if (difference < smallestDifference)
                {
                    smallestDifference = difference;
                    keys = new List<int>() { entry.Key };
                }
                else if (difference == smallestDifference)
                {
                    keys.Add(entry.Key);
                }
            }
            var candidates = dictionary.Where(x => x.Key == smallestDifference).ToList();
            if ( candidates.Count == 1)
            {
                return candidates.SingleOrDefault();
            }
            return candidates.SingleOrDefault(y => y > input);
