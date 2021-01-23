    public static void WriteSomeText(string text) 
    {
        string path = Path.Combine(AppDomain.BaseDirectory, "mytextfile.txt");
        using (StreamWriter sw = File.CreateText(path)) 
        {
            sw.WriteLine(text);
        }
    }
