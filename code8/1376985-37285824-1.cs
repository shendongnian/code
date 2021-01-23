    StringBuilder output = new StringBuilder();
    foreach (var f in files)
    {
        string path = f.File.ToString();
        string filename = Path.GetFileName(path);
        string s = string.Empty;
        using (StreamReader reader = new StreamReader(path, true))
        {
            using (var sw = File.CreateText(Path.Combine(newPath + @"\Test", filename + ".txt")))
            {
                foreach(var s in reader.ReadLines())
                {
                    output.Clear();
                    string[] parts = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                     
                    foreach (string st in parts)
                    {
                        output.Append(st).Append(",");
                    }
                    sw.Write(output.ToString());
                }
            }
        }
    }
