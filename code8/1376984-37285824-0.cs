    foreach (var f in files)
    {
        string path = f.File.ToString();
        string filename = Path.GetFileName(path);
        string s = string.Empty;
        using (StreamReader reader = new StreamReader(path, true))
        {
            foreach(var s in reader.ReadLines())
            {
                using (var sw = File.CreateText(Path.Combine(newPath + @"\Test", filename + ".txt")))
                {
                   sw.Write(output.Replace(" ",","));
                }
            }
        }
    }
