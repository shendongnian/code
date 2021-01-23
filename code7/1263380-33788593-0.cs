    using (StreamReader sr = new StreamReader(filename))
    {
        string [] datarow;
        colt = sr.ReadLine();
        string[] columns = colt.Split(';');
        Count = columns.Length;
        foreach (string c in columns)
        {
            table.Columns.Add(c, typeof(String));
        }
        while (!sr.EndOfStream)
        {
            rowt = sr.ReadLine();
            datarow = rowt.Split(';');
            table.Rows.Add(datarow);
        }
        Table1.DataSource = table;
    }
