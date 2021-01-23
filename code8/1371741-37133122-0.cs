    class favorite
    {
        public int id { get; set; }
        public bool isDefault { get; set; }
        public string title { get; set; }
    }
    // code in main method
    f.Add( new favorite {id = 1, title ="MEN", isDefault=true });
    f.Add(new favorite { id = 2, title = "WOMEN", isDefault=true });
    f.Add(new favorite { id = 3, title = "BOYS", isDefault=true });
    f.Add(new favorite { id = 4, title = "GIRLS", isDefault=true });
    // rest of your code, note that boolean defaults to false if you do not set it so the rest of your instances do not require change
    // Descending should put true first then false, then order by the title
    foreach (var item in f.OrderByDescending(e=>e.isDefault).ThenBy(e=>e.title))
    {
       Console.WriteLine(item.title);
    }
