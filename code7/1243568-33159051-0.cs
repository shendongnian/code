    class Program
    {
        static void Main(string[] args)
        {
            var input = new[] { 1, 2, 3, 4 };
            var result = GenerateSubsets(input)
                .Where(s => s.Sum() % input.Length == 0)
                .ToArray(); // {1, 3}, {4} and {1, 3, 4};
        }
        static IEnumerable<ICollection<T>> GenerateSubsets<T>(ICollection<T> set)
        {
            // Base case
            if (set.Count == 0)
            {
                yield return new T[0];
                yield break;
            }
            // Generate all subsets
            var i = set.First();
            foreach (var subset in GenerateSubsets(set.Except(new[] { i }).ToArray()))
            {
                yield return subset;
                yield return subset.Concat(new[] { i }).ToArray();
            }
        }
    }
