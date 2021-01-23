        class Program
    {
        static void Main(string[] args)     
         {
            List<String> list = new List<string>() { "A", "A", "B", "B", "B", "A", "A", "A"};
            var groups = list.GroupAdjacentBy(x => x);
            foreach(var group in groups)
                Console.WriteLine(string.Format("Key: {0}, Count: {1}", group.Key, group.Count()));
            Console.ReadLine();
         }
    }
