    class items {
                 public  int id;
                 public string name;
                }
    static void Main(string[] args)
            {
                var list = new List<items>();
                list.Add(new items {id=1 , name="a"});
                list.Add(new items { id = 2, name = "b" });
                list.Add(new items { id = 3, name = "c" });
                var list1 = new List<items>();
                list1.Add(new items { id = 2, name = "b" });
                list1.Add(new items { id = 3, name = "c" });
                list1.Add(new items { id = 4, name = "d" });
    
                var c = list.Select(b=> new {b.id, b.name});
                var d = list1.Select(b => new { b.id, b.name });
                var merge = c.Concat(d).Distinct().ToList();
        
                foreach (var item in merge)
                {
                    Console.WriteLine(item);
                }
    
               Console.ReadKey();
         }
