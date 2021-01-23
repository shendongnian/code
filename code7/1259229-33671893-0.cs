    var file = File.ReadLines("path");
    var sb = new StringBuilder();
    foreach (var t in file)
    {
       if(!string.IsNullOrWhiteSpace(t))
            sb.AppendLine("'" + t + "',");
    }
    File.WriteAllLines("path", new string[] { sb.ToString() });
