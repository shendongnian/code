    foreach (FieldInfo p in t.GetFields())
    {
        Console.WriteLine("-");
        Console.WriteLine(p.GetType().ToString());
        Console.WriteLine(p.Name.ToString());
        Console.WriteLine(p.FieldType.GetType().ToString());
        Console.WriteLine(p.FieldType.GetTypeCode().ToString());
        Console.WriteLine(p.FieldType.ToString());
    }  
