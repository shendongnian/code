    static void Main(string[] args)
        {
            WhereDelegate del = (int element) => element < 5;
            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            IEnumerable<int> query = list.Where(x => del(x));  
        }
