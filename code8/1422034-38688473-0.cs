    class Program
    {
        static void Main(string[] args)
        {
            var initialArray = new[] { 0, 1, 3, 5 };
            var subArrayLength = 2;
            foreach (var subArray in GetSubArrays(initialArray, subArrayLength))
                Console.WriteLine($"[{string.Join(", ", subArray)}]");
            Console.WriteLine("Searching for array that contains both 1 and 5.");
            var arrayFulfillingCriteria = GetSubArrays(initialArray, subArrayLength).FirstOrDefault(array => array.Contains(1) && array.Contains(5));
            if (arrayFulfillingCriteria != null)
                Console.WriteLine($"[{string.Join(", ", arrayFulfillingCriteria)}]");
            else
                Console.WriteLine("No array found.");
        }
        static IEnumerable<int[]> GetSubArrays(int[] initialArray, int subArrayLength)
        {
            var indexStack = new Stack<int>(Enumerable.Range(0, subArrayLength));
            do
            {
                var subArray = indexStack.Select(i => initialArray[i]).Reverse().ToArray();
                yield return subArray;
                var index = indexStack.Pop();
                while (indexStack.Count != 0 && indexStack.Count < subArrayLength && index == initialArray.Length - (subArrayLength - indexStack.Count))
                    index = indexStack.Pop();
                while (indexStack.Count < subArrayLength && index < initialArray.Length - (subArrayLength - indexStack.Count))
                {
                    index++;
                    indexStack.Push(index);
                }
            }
            while (indexStack.Count != 0);
        }
    }
