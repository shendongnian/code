	public void XMLWriteNewL4Module()
    {
		
        String workingDir = Directory.GetCurrentDirectory();
        int i;
        if (File.Exists(workingDir + @"Level4Modules.xml") == false)
        {
            //create a new file in the working directory
            XmlTextWriter textWriter = new XmlTextWriter("Level4Modules.xml", null);
            textWriter.WriteStartElement("Modules");
            textWriter.WriteEndElement();
            textWriter.Close();
        }
        XElement xDoc = XElement.Load(workingDir + @"Level4Modules.xml");
        xDoc.Add(
        new XElement("Module",
            new XElement("Title", this.textBoxStudentFirstName.Text),
            new XElement("Code", this.textBoxStudentSurname.Text),
            new XElement("Credit Value", this.textBoxStudentIDNewUser.Text),
            new XElement("Assessments", Enumerable.Range(0,numericUpDownNoOfAssessments.Value)
						 .Select(i=>
						 {	 
							 return new XElement[] {
								new XElement("Assessment Type", (comboBoxAssessments[i] as ComboBox).Text),
								new XElement("Assessment Grade"),
								new XElement("Assessment Weighting")
							 };
							 
						 }))));	  
            
        xDoc.Save(workingDir + @"\Students.xml");
    }	
