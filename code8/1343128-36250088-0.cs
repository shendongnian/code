    public class MyClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public override string ToString()
        {
            return string.Format("{0}: {1} - {2}", Id, Name, ParentId);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<MyClass> list = new List<MyClass>();
            list.Add(new MyClass { Id = 1, Name = "Item1", ParentId = null });
            list.Add(new MyClass { Id = 2, Name = "Item2", ParentId = 1 });
            list.Add(new MyClass { Id = 3, Name = "Item3", ParentId = 2 });
            list.Add(new MyClass { Id = 4, Name = "Item4", ParentId = 2 });
            list.Add(new MyClass { Id = 5, Name = "Item5", ParentId = 3 });
            list.Add(new MyClass { Id = 6, Name = "Item6", ParentId = 1 });
            list.Add(new MyClass { Id = 7, Name = "Item7", ParentId = null });
            list.Add(new MyClass { Id = 8, Name = "Item8", ParentId = 2 });
            list.Add(new MyClass { Id = 9, Name = "Item9", ParentId = 6 });
            list.Add(new MyClass { Id = 10, Name = "Item10", ParentId = 7 });
            foreach(var item in list.Where(x => !x.ParentId.HasValue).OrderBy(x => x.Id))
                ProcessItem(item, list, 0);
            Console.ReadKey();
        }
        private static void ProcessItem(MyClass item, List<MyClass> list, int level)
        {
            Console.WriteLine("{0}{1}", new string(' ', level * 2), item.ToString());
            foreach (var subitem in list.Where(x => x.ParentId == item.Id).OrderBy(x => x.Id))
                ProcessItem(subitem, list, level  + 1);
        }
    }
