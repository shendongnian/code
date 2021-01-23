    foreach (var item in procsMods)
    {
        Console.WriteLine(string.Format("{0} ({1}):", item.Value.FileProc.Name, item.Key));
        foreach (var mod in item.Value.Modules)
        {
            Console.WriteLine("\t{0}", mod.FileMod.Name);
        }
    }
