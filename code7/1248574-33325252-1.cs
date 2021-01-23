	while (input.Position < input.Length) {
		var record = (RecordSerializable)formatter.Deserialize(input);
        string[] values = new string[] 
        {
            record.Name.ToString(),
            record.StudentID.ToString(),
            record.Grade.ToString()
        }; // end string[] values
            // copy string array values to TextBox values
        SetValuesToListBox(values);
	}
