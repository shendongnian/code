    foreach (DataRow r in T.Rows)
    {
        if(r[0]!="A") break;
        line = "";
        for (int i = 0; i < T.Columns.Count; i++)
        {
            line = line + r[i].ToString() + d;
        }
        sb.AppendLine(line);
    }
    File.WriteAllText(filePath, sb.ToString());
