    class Puzzle
    {
        public readonly SubsetElement[] Elements;
        public readonly int N;
        public Puzzle(int[] numbers)
        {
            // Set N and make Elements array
            // (to remember the original index of each element)
            this.N = numbers.Length;
            this.Elements = new SubsetElement[this.N];
            for (var i = 0; i < this.N; i++)
            {
                this.Elements[i] = new SubsetElement(numbers[i], i);
            }
            // Sort Elements descendingly by their Number value
            Array.Sort(this.Elements, (a, b) => b.Number.CompareTo(a.Number));
        }
        public void Solve(int s, Action<SubsetElement[]> callback)
        {
            for (var k = 1; k <= this.N; k++)
                this.Solve(k, s, callback);
        }
        public void Solve(int k, int s, Action<SubsetElement[]> callback)
        {
            this.ScanSubsets(0, k, s, new List<SubsetElement>(), callback);
        }
        private void ScanSubsets(int startIndex, int k, int s,
                                 List<SubsetElement> subset, Action<SubsetElement[]> cb)
        {
            // No more numbers to add, and current subset is guranteed to be valid
            if (k == 0)
            {
                // Callback with current subset
                cb(subset.ToArray());
                return;
            }
            // Sum the smallest k elements
            var minSum = 0;
            var minSubsetStartIndex = this.N - k;
            for (var i = minSubsetStartIndex; i < this.N; i++)
            {
                minSum += this.Elements[i].Number;
            }
            // Smallest possible sum is greater than wanted sum,
            // so a valid subset cannot be found
            if (minSum > s)
            {
                return;
            }
            // Find largest number that satisfies the condition
            // that a valid subset can be found
            minSum -= this.Elements[minSubsetStartIndex].Number;
            // But remember the last index that satisfies the condition
            var minSubsetEndIndex = minSubsetStartIndex;
            while (minSubsetStartIndex > startIndex &&
                   minSum + this.Elements[minSubsetStartIndex - 1].Number <= s)
            {
                minSubsetStartIndex--;
            }
            // Find the first number in the sorted sequence that is
            // the largest number we just found (in case of duplicates)
            while (minSubsetStartIndex > startIndex &&
                   Elements[minSubsetStartIndex] == Elements[minSubsetStartIndex - 1])
            {
                minSubsetStartIndex--;
            }
            // [minSubsetStartIndex .. maxSubsetEndIndex] is the
            // full range we must check in recursion
            for (var subsetStartIndex = minSubsetStartIndex;
                 subsetStartIndex <= minSubsetEndIndex;
                 subsetStartIndex++)
            {
                // Find the largest possible sum, which is the sum of the
                // k first elements, starting at current subsetStartIndex
                var maxSubsetIndexEdge = subsetStartIndex + k;
                var maxSum = 0;
                for (var i = subsetStartIndex; i < maxSubsetIndexEdge; i++)
                {
                    maxSum += this.Elements[i].Number;
                }
                // The largest possible sum is less than the wanted sum,
                // so a valid subset cannot be found
                if (maxSum < s)
                {
                    return;
                }
                // Add current number to the subset
                var x = this.Elements[subsetStartIndex];
                subset.Add(x);
                // Recurse through the sub-problem to the right
                this.ScanSubsets(subsetStartIndex + 1, k - 1, s - x.Number, subset, cb);
                // Remove current number and continue loop
                subset.RemoveAt(subset.Count - 1);
            }
        }
        public sealed class SubsetElement
        {
            public readonly int Number;
            public readonly int Index;
            public SubsetElement(int number, int index)
            {
                this.Number = number;
                this.Index = index;
            }
            public override string ToString()
            {
                return string.Format("{0}({1})", this.Number, this.Index);
            }
        }
    }
