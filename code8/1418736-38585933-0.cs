    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            IEnumerable<int> query = list.Where(isInGroup);
            foreach (int i in query)
            {
                Console.WriteLine(i);
            }
        }
        public static bool isInGroup(int elem)
        {
            return elem < 5;
        }
    }
