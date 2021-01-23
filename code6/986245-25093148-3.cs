    StringBuilder sb = new StringBuilder();
    foreach(DataRow r in newTable.Rows)
    {
        sb.AppendLine("\"" + string.Join("\",", r.ItemArray) + "\"");
    }
    Console.WriteLine(sb.ToString());
