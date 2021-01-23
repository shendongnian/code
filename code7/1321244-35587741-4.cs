	MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
	MyReader.Delimiters = new string[] { Constants.vbTab };
	string[] currentRow = null;
	//Loop through all of the fields in the file. 
	//If any lines are corrupt, report an error and continue parsing. 
	while (!MyReader.EndOfData) {
		try {
			currentRow = MyReader.ReadFields();
			// Include code here to handle the row.
		} catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex) {
			Interaction.MsgBox("Line " + ex.Message + " is invalid.  Skipping");
		}
	}
}
