    static void Main(string[] args)
        {
            var data = new[] {"4.5","2.1","2.2.1","7.5","7.5.3",@"N/A","2.3.4.5"};
            foreach(var v in data.OrderByDescending(OrderVersion))
                Console.WriteLine(v);
        }
        private static IComparable OrderVersion(string arg)
        {
            //Treat N/A as highest version
            if (arg == "N/A")
                return new Version(Int32.MaxValue,Int32.MaxValue); 
            return Version.Parse(arg);
        }
