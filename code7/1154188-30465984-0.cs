    var strdizi = new string [] {"Andy", "Arthur", "Ashlynn", "Ben", "Chris"};
    var query = strdizi.GroupBy(g=>g.Substring(0,1));
    foreach (var item in query)
    {
        Console.WriteLine(item.Key + " " + item.Count());
        foreach (var items in item)
        {
            Console.WriteLine(items);
        }
    }
