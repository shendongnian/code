    foreach (var f in files)
    {
        string path = f.File.ToString();
        string filename = Path.GetFileName(path);
        string s = string.Empty;
        using (var sw = File.CreateText(Path.Combine(newPath + @"\Test", filename + ".txt")))
        {
            foreach(var s in File.ReadLines(path))
            {
                string[] parts = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                     
                foreach (string st in parts)
                {
                    sw.Write(st);
                    sw.Write(",");
                }
            }
        }
    }
