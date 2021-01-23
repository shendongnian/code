    var lst = new List<string>();
    lst.Add("test1");
    lst.Add("test2");
    lst.Add("test3");           
    foreach (var item in lst)
    {
        Console.WriteLine(item); // item, not list
    }
    Console.Read();
