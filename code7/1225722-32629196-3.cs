    //list of class values               
	rootValues valusList = new rootValues();
		
	foreach (Control control in Controls)
	{
	    values value = new values();
		
		value.ctrlname = control.Name.ToString();
		value.ctrllocation = control.Location.ToString();
	    value.ctrltext = control.Text.ToString();
		value.ctrltype = control.GetType().ToString();
		value.ctrlstatus = control.Enabled.ToString();
		
		valuesList.valuesList.Add(value);    
	}
	
	System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(rootValues));
	var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Serialization.xml";
	System.IO.FileStream file = System.IO.File.Create(path);
    writer.Serialize(file, valusList);
	file.Close();
	
	
