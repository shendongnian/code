    class SneakierProgram
    {
        static void Main(string[] args)
        {
            var input = "0 1 2 4 6 7";
            var result = Solve(input);
        }
        private static int Solve(string input)
        {
            int? best = null;
            int a, b;
            var unvalidatedDigits = input.Split(' ').Select(i => int.Parse(i));
            var digits = ValidateInput(unvalidatedDigits);
            // Special case because the even algorithm doesn't play nicely if there are exactly (2)
            // digits and one of them is 0.
            if (digits.Length == 2)
            {
                // However since it's already sorted and there are only 2 digits we know what to do.
                best = digits[1] - digits[0];
            }
            else if (digits.Length % 2 == 1)
            {
                // Are there an odd number of digits to choose from?
                // If so the most sigificant needs to be 0 for the smaller number.
                var b0 = 0;
                // That forces the most sigificant needs to be the minimum non-0 for the larger number.
                var a0 = digits.Except(new[] { 0 }).Min();
                // The 0 for b0 doesn't count/shouldn't be excluded.
                // Note remaining now has an even number of digits left.
                var remaining = digits.Except(new[] { a0 });
                OptimizeRemainingDigits(remaining, a0, b0, out a, out b);
                best = a - b;
            }
            else
            {
                // There are an even number of digits to choose from, so each number will contain
                // an equal number of digits.  The most sigificant digits most affect the difference
                // so minimizing them is our greatest concern.  Since the array is sorted we only
                // need to consider adjacent pairs.
                var nonZeroDigits = digits.Except(new[] { 0 }).ToArray();
                // There will be one less adjacent pair than the total to choose from.
                var adjacentPairIndices = Enumerable.Range(0, nonZeroDigits.Length - 1);
                // Project the adjacent pairs.
                var adjacentPairs = adjacentPairIndices.Select(i => new
                {
                    // The larger will be one past the index.
                    Larger = nonZeroDigits[i + 1],
                    // The smaller will be at the index.
                    Smaller = nonZeroDigits[i]
                });
                // Group adjacent pairs by their difference.
                var groupedAdjacentPairs = adjacentPairs.ToLookup(pair => pair.Larger - pair.Smaller);
                // Find the minimum difference.
                var minimumDifference = groupedAdjacentPairs.Select(g => g.Key).Min();
                // Consider only the adjacent pairs that have minimum difference.
                var candidates = groupedAdjacentPairs[minimumDifference];
                foreach (var candidate in candidates)
                {
                    // The most sigificant needs to be smaller for the smaller number.
                    var b0 = candidate.Smaller;
                    // The most sigificant needs to be larger for the larger number.
                    var a0 = candidate.Larger;
                    // Both used digits need to be excluded.
                    // Note remaining still has an even number of digits left.
                    var remaining = digits.Except(new[] { a0, b0 });
                    OptimizeRemainingDigits(remaining, a0, b0, out a, out b);
                    var possibleBetter = a - b;
                    if (possibleBetter < (best ?? int.MaxValue))
                    {
                        best = possibleBetter;
                    }
                }
            }
            return best ?? -1;
        }
        private static void OptimizeRemainingDigits(
            IEnumerable<int> remaining, 
            int a0, 
            int b0, 
            out int a, 
            out int b)
        {
            // Acculmuate the digits of a on a string.
            var aString = a0.ToString();
            // Acculumate the digits of b on a string (b can be 0, in which case don't count that as a digit).
            var bString = b0 == 0 ? "" : b0.ToString();
            // Each number will get half the remaining digits.
            var digitsPerNumber = remaining.Count() / 2;
            // The larger number gets the smaller digits from least to greatest 
            // to minimize its overall value.
            aString += string.Join("", remaining.
                OrderBy(i => i).Take(digitsPerNumber));
            // The smaller number gets the larger digits from greatest to least 
            // to maximize its overall value.
            bString += string.Join("", remaining.
                OrderByDescending(i => i).Take(digitsPerNumber));
            a = int.Parse(aString);
            b = int.Parse(bString);
        }
        private static int[] ValidateInput(IEnumerable<int> input)
        {
            // Make sure at least (2) integers were entered.
            if (input == null || input.Count() < 2)
            {
                // TODO
                throw new Exception();
            }
            // Make sure you don't have duplicates.
            var result = input.Distinct().ToArray();
            // Make sure the numbers are in range.
            if (result.Min() < 0 || result.Max() > 9)
            {
                // TODO
                throw new Exception();
            }
            return result;
        }
    }
