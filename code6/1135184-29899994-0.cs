    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < lines.Count; i++)
    {
        if(lines[i].Contains("1901"))
        {         
             sb.AppendLine(lines[i].Replace("< 1901,",""));
        }
        else
        {
            sb.AppendLine(lines[i]);
        }
    }
    using (StreamWriter writer = new StreamWriter(path))
    {
        writer.Write(sb.ToString());
    }
