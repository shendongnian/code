        public static IEnumerable<IEnumerable<int>> GetCombinations(IEnumerable<int> dimensions)
        {
            if (!dimensions.Any())
            {
                yield return Enumerable.Empty<int>();
                yield break;
            }
            var first = dimensions.First();
            foreach (var subSolution in GetCombinations(dimensions.Skip(1)))
            {
                for (var i = 0; i < first + 1; i++)
                {
                    yield return new[] { i }.Concat(subSolution);
                }
            }
        }
