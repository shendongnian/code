    using (var doc = WordprocessingDocument.Open("OpenXMLTest.docx", false))
    {
    	Console.WriteLine("Title = " + doc.ExtendedFilePropertiesPart.Properties.TitlesOfParts.InnerText);
    	Console.WriteLine("Subject = " + doc.PackageProperties.Subject);
    	{
    		foreach (var control in doc.ContentControls())
    		{
    			Console.WriteLine( control.Title + "==>" + control.Value);
    		}
    	}
    }
