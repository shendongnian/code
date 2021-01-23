    void Main()
    {
    	XNamespace empNM = "urn:lst-emp:emp";
    	XDocument xDoc ;
    	string path="C:\\tempFolder\\test.xml";
    	if(!File.Exists(path))
    	{
    		 xDoc = new XDocument(
    					new XDeclaration("1.0", "UTF-16", null),
    					new XElement(empNM + "Employees")
    					);
    	}
    	else
    	{
    	   xDoc=XDocument.Load(path);
    	}
    	
    	var element=new XElement("Employee",
    							new XComment("Only 3 elements for demo purposes"),
    							new XElement("EmpId", "5"),
    							new XElement("Name", "Kimmy"),
    							new XElement("Sex", "Female"));
    	xDoc.Element(empNM+"Employees").Add(element);
    		
    		// Save to Disk
    		xDoc.Save(path);
    		Console.WriteLine("Saved");
    }
