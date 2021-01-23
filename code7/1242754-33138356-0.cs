        public static IEnumerable<string> GetPermutations(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<string>();
            }
            var length = input.Length;
            var indices = Enumerable.Range(0, length).ToList();
            var permutationsOfIndices = GetNumericalPermutations(indices, length);
            var permutationsOfInput = permutationsOfIndices.Select(x => new string(x.Select(y => input[y]).ToArray()))
                                                           .Distinct();
            return permutationsOfInput;
        }
        private static List<List<int>> GetNumericalPermutations(List<int> values, int maxLength)
        {
            if (maxLength == 1)
            {
                return values.Select(x => new List<int>{x}).ToList();
            }
            else
            {
                var permutations = GetNumericalPermutations(values, maxLength - 1);
                foreach (var index in values)
                {
                    var newPermutations = permutations.Where(x => !x.Contains(index))
                                                      .Select(x => x.Concat(new List<int> { index }))
                                                      .Where(x => !permutations.Any(y => y.SequenceEqual(x)))
                                                      .Select(x => x.ToList())
                                                      .ToList();
                    permutations.AddRange(newPermutations);
                }
                return permutations;
            }
        }
