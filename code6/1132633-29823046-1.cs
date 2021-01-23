    class Program
    {
        static void Main(string[] args)
        {
            var array = new List<Int32>() { 1, 2, 3, 4 };
            var condition = false;                              // change it to see different outputs
            array
                .WhereIf<Int32>(condition, x => x % 2 == 0)     // predicate will be applied only if condition TRUE
                .WhereIf<Int32>(!condition, x => x % 3 == 0)    // predicate will be applied only if condition FALSE
                .ToList()                                       // don't call ToList() multiple times in the real world scenario
                .ForEach(x => Console.WriteLine(x));  
        }
    }
