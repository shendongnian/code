    public DataTable CreateDataTable(string fileName)
    {
        XElement xml = XElement.Load(fileName);
        var tempRows = from x in xml.Descendants("x")                       
                       select new
                       {
                           A = (string)x.Element("a"),
                           B = (string)x.Element("b"),
                           C = (string)x.Element("c")
                       };
        DataTable dt = new DataTable();
        dt.Columns.Add("a", typeof(string));
        dt.Columns.Add("b", typeof(string));
        dt.Columns.Add("c", typeof(string));            
        foreach (var tempRow in tempRows)
        {
            dt.Rows.Add(tempRow.A, tempRow.B, tempRow.C);
        }
        return dt;
    }
