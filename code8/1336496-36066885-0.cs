    class Program
    {
        static void Main(string[] args)
        {
            List<Component> firstlist = new List<Component>();
            List<Component> secondlist = new List<Component>();
            firstlist.Add(new Component { id = 1, Name = "Jhon" });
            secondlist.Add(new Component { id = 2, Name = "Jhon" });
    
            var test = from d in firstlist
                                     join i in secondlist
                                     on d.id equals i.id
                                     into a
                                     from b in a.DefaultIfEmpty()
                                     select new Component { id = (b != null) ?b.id : default(int), Name = (b != null) ? b.Name : default(string) };
            List<Component> Result = test.ToList();
        }
    
        public class Component
        {
            public int id { get; set; }
    
            public string Name { get; set; }
        }
    }
