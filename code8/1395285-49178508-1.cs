    private static IEnumerable<int[]> GetUniqueArrays(IEnumerable<int[]> source)
        {
            var knownKeys = new HashSet<string>();
            foreach (var element in source)
            {
                if (knownKeys.Add(string.Join(",", element)))
                    yield return element;
            }
        }
