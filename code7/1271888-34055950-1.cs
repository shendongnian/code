        public static IEnumerable<IEnumerable<string>> GenerateBlocks(string s)
        {
            // The base case is trivial: the blocks of the empty string 
            // is the empty set of blocks.
            if (s.Length == 0)
            {
                yield return new string[0];
                yield break;
            }
            // Generate all the sequences for the middle;
            // combine them with all possible prefixes and suffixes.
            for (int i = 1; s.Length >= 2 * i; ++i)
            {
                string prefix = s.Substring(0, i);
                string middle = s.Substring(i, s.Length - 2 * i);
                string suffix = s.Substring(s.Length - i, i);
                foreach (var body in GenerateBlocks(middle))
                    yield return AffixSequence(prefix, body, suffix);
            }
            // Finally, the set of blocks that contains only this string
            // is a solution.
            yield return new[] { s };
        }
