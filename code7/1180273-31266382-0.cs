    class Something
    {
        public string Code;
        public Something(string code)
        {
            this.Code = code;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Something> ListDS = new List<Something>();
            ListDS.Add(new Something("test1"));
            ListDS.Add(new Something("searchword1"));
            ListDS.Add(new Something("test2"));
            ListDS.Add(new Something("searchword2"));
            string searchcode = "searchword";
            var find = ListDS.First(x => x.Code.Contains(searchcode));
            Console.WriteLine(find.Code);
            Console.ReadKey();
        }
    }
