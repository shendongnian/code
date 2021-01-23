    string myXMLfile = @"C:\myfile.xml";
    DataSet ds = new DataSet();
    
    // Create new FileStream with which to read the schema.
    System.IO.FileStream fsReadXml = new System.IO.FileStream 
    	(myXMLfile, System.IO.FileMode.Open);
    try
    {
    	ds.ReadXml(fsReadXml);
    	dataGrid1.DataSource = ds.Table[0].DefaultView;	
        // or  dataGrid1.DataSource = ds;	 
    }
    finally
    {
    	fsReadXml.Close();
    }
