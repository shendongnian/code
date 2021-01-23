    TextWriter writer = Console.Out; // File.CreateText(@"...");
    foreach (var group in result)
    {
        writer.WriteLine("Start - " + group.Key);
        foreach (var item in group)
            writer.WriteLine(item.row.Field<string>("Name"));
        writer.WriteLine("End");
        writer.WriteLine();
    }
