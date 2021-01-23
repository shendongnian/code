            Dictionary<string, int> ab = new Dictionary<string, int>
            {
                {"a", 1},
                {"b", 0},
                {"c", 3},
                {"d", 0},
                {"e", 5}
            };
            foreach(var pair in ab)
            {
                if(pair.Value != 0)
                    Console.WriteLine(pair.Key + ":" + pair.Value);
            }
