    DataTable dt = new DataTable();
    DataColumn dc = new DataColumn("ID", Type.GetType("System.Int32"));
    dt.Columns.Add(dc);
    dc = new DataColumn("sID", Type.GetType("System.String"));
    dt.Columns.Add(dc);
    dc = new DataColumn("FirstName", Type.GetType("System.String"));
    dt.Columns.Add(dc);
    dc = new DataColumn("LastName", Type.GetType("System.String"));
    dt.Columns.Add(dc);
    
    XDocument xDoc = new XDocument();
    XElement xRoot = new XElement("Categories");
    foreach (DataColumn c in dt.Columns)
    {
    	xRoot.Add(new XElement("Category", new XAttribute("label", c.ColumnName)));
    }
    
    xDoc.Add(xRoot);
