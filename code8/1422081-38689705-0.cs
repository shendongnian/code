            var list_1 = new List<List<int>>
            {
                new List<int> { 234, 45, 1, 86, 2, 0 },
                new List<int> { 324, 6, 1 },
                new List<int> { 123, 1111, 3 }
            };
            var list_2 = new List<string>
            {
                "Alpha",
                "Beta",
                "Gamma"
            };
            var dictionary = new Dictionary<string, List<int>>();
            list_2.ForEach(x =>
            {
                int index = list_2.IndexOf(x);
                dictionary.Add(list_2[index], list_1[index]);
            });
