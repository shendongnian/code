    Regex r = new Regex("[aAeEiIoOuU]");
    string[] names = new string[5];
    names[0] = "john";
    names[1] = "samuel";
    names[2] = "kevin";
    names[3] = "steve";
    names[4] = "martyn";
    for (int i = 0; i < names.Length; i++)
    {
        names[i] = r.Replace(names[i], "");
        Console.WriteLine("The output is:" + names[i]);
    }
