	// Load or instantiate
	
	string xmlFileName = "yourfilename.xml";	
	RootObject rootObject;
		
	if (File.Exists(xmlFileName))
	{
		rootObject = LoadData(xmlFileName);
	}
	else
	{
		rootObject = new RootObject
		{
			NestedObject = new RootObjectNestedObject[]			
		};
	}
	
	// Modify
	
	var nestedObjects = new List<RootObjectNestedObject>(rootObject.NestedObject);
	
	nestedObjects.Add(new RootObjectNestedObject
	{
		ID = 42,
		VCODE = "foo",
		APIKEY = "bar"
	});
	
	// Save
	rootObject.NestedObject = nestedObjects.ToArray();
	
	SaveData(xmlFileName, rootObject);
