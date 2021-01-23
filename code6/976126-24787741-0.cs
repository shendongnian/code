    string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    List<string> batFiles = new List<string>();
    batFiles.Add(Path.Combine(path, "down_fa.bat"));
    batFiles.Add(Path.Combine(path, "down_ng.bat"));
    batFiles.Add(Path.Combine(path, "down_os.bat"));
    batFiles.Add(Path.Combine(path, "down_sp.bat"));
    string portinput = Console.ReadLine();
    string dotbatinput = "DDL -p" + portinput;
    foreach(string batFile in batFiles)
    {
        using (FileStream fs = File.OpenWrite(batFile))
        {
         -----
        }
    }
