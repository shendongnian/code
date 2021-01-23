    XDocument doc = XDocument.Load("test.xml");
    // Create two DataTable instances.
	DataTable table1 = new DataTable("patients");
	table1.Columns.Add("name");	
    foreach(var name in doc.Root.DescendantNodes().OfType<XElement>()
            .Select(x => x.Name).Distinct())
    {
     	table1.Rows.Add(name);
        Console.WriteLine(name);       
    }
