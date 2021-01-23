    StringBuilder sb = new StringBuilder();
    foreach (string file in System.IO.Directory.GetFiles(txtpath3.Text, "*.*"))
    {
       sb.AppendLine(file);
    }
    File.WriteAllText(dirfile3, sb.ToString());
