        public static IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list,       Func<IEnumerable<T>, Boolean> filter)
        {
            var fullPowerSet = from m in Enumerable.Range(0, 1 << list.Count)
                         select
                           from i in Enumerable.Range(0, list.Count)
                           where (m & (1 << i)) != 0
                           select list[i];
            return fullPowerSet.Where(e => filter(e));
        }
        static void Main(String[] args)
        {
            List<Int32> inputList = new List<Int32>()
            {
                1,2
            };
            var result = GetPowerSet(inputList, ps => ps.Sum() > 1);
        }
