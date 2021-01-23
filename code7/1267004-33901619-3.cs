       //Open the intialInspections xml file and load the values into the form
       XmlDocument xdoc = new XmlDocument();
       FileStream rFile = new FileStream(values.xmlInitialFileLocation, FileMode.Open);
       xdoc.Load(rFile);
       XmlNodeList list = xdoc.GetElementsByTagName("initialInspection");
       // create list of initialInspectionNotes in order to add as many nodes as needed
       var notes = new List<initialInspectionNotes>();
       // map data
       for (int i = 0; i < list.Count; i++)
       {
       	   // read data
           XmlElement initialInspection = (XmlElement)xdoc.GetElementsByTagName("initialInspection")[i];
           XmlElement initialInspector = (XmlElement)xdoc.GetElementsByTagName("userInspection")[i];
           XmlElement dateTime = (XmlElement)xdoc.GetElementsByTagName("dateTime")[i];
           propertyID = int.Parse(initialInspection.GetAttribute("propertyID"));
           initialInspectorUsername = initialInspector.InnerText;
           intialDateTime = DateTime.Parse(dateTime.InnerText);
    	   // fetch notes!
    	   var inspectionNotes = initialInspection.SelectNodes("inspectionNote");
    	   foreach (XmlNode inspectionNote in inspectionNotes)
    	   {
    	   		// insert data into list
    		    notes.Add(new initialInspectionNotes
    								{
    									locationExtraNote = inspectionNote.SelectSingleNode("locationNote").Value,
    									costCode = inspectionNote.SelectSingleNode("CostCode").Value,
    									locationWithinProperty = inspectionNote.SelectSingleNode("location").Value
    								});
    	   }
       }
       // convert to array if needed
       //var arrayOfNotes = notes.ToArray();
       rFile.Close();
