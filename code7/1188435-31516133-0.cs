        static void Main(string[] args)
        {
            List<int[]> nums = new List<int[]> { new int[] { 3, 1, 2 }, new int[] { 5, 2, 4 } };
            foreach (var row in nums)
            {
                Array.Sort(row);
            }
            foreach (var row in nums)
            {
                foreach (int i in row) Console.Write(i + " "); 
            }
        }
