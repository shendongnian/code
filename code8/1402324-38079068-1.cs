    class Program
    {
        static void Main(string[] args)
        {
            var i = new int?[] { 1, 2, 3 };
            foreach (var n in i.WithNext())
                //the last value will be paired with a null.  
                // you can use null coalesce to fill in the missing item.
                Console.WriteLine("{0} => {1}", n.Item1, n.Item2 ?? 9);
            /*
                1 => 2
                2 => 3
                3 => 9
             */
        }
    }
