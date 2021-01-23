    Console.Write("CombineList");
    foreach( var item in result.CombineList)
    {
        Console.Write(item.name + " ");
    }
    Console.WriteLine("");
    Console.Write("DivisionList");
    foreach( var item in TypesList.Where( t => t.type == "Division"))
    {
        Console.Write(item.name + " ");
    }
