    while ((a = sr.ReadLine()) != null)
    {
        a = a.Substring(1, a.Length - 2);
        string[] columns = a.Split(new string[] { "\",\"" }, StringSplitOptions.None);
        if (dt == null)
        {
            dt = new DataTable();
            for (int i = 0; i < columns.Count(); i++)
                dt.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
        }
        dt.Rows.Add(a.Split(new char[] { ',' }).ToArray());
    }
