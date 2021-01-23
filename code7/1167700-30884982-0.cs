    if (File.Exists(path))
    {
        using (TextReader tr = new StreamReader(path))
        {
            while (tr.Peek() != -1)
            {
                var htmlLine = tr.ReadLine().Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;") + "<br/>";
                Response.Write(htmlLine);
            }
        }
    }
