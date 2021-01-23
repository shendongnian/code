	string updateQuery = "UPDATE " + tableEmployeeContact + @" SET 
	     LastUpdate=?
		,EmployeeAddress1=?
		,EmployeeAddress2=?
		,EmployeeCity=?
		,EmployeeState=?
		,EmployeeZip=?
		,EmployeeHomePhone=?
		,EmployeeCellPhone=?
		,EmployeeHomeEmail=?
		,EmergencyContactName=?
		,EmergencyContactRelationship=?
		,EmergencyContactHomePhone=?
		,EmergencyContactCellPhone=?
		,EmergencyContactWorkPhone=?
	 WHERE EmployeeLastName=? AND EmployeeFirstName=?";
	 
	using (OleDbConnection connection = new OleDbConnection(connectionString))
	{
		OleDbCommand command = new OleDbCommand(updateQuery, connection);
		connection.Open();
		if(connection.State == ConnectionState.Open)
		{
			// In MS Access the order of parameters is critical!!
			
			// I recommend replacing this with the below commented out parameter and changing your data type in MS Access accordingly. The type system is in place for a reason, not everything is a string.
			command.Parameters.Add("@CurrentTimeStamp", OleDbType.VarChar).Value = labelTimeStamp.Text.Trim();
			// command.Parameters.Add("@CurrentTimeStamp", OleDbType.DBTimeStamp).Value = DateTime.Now;
			
			command.Parameters.Add("@EmployeeAddress1", OleDbType.VarChar).Value = cm.EmployeeAddress1;
			command.Parameters.Add("@EmployeeAddress2", OleDbType.VarChar).Value = cm.EmployeeAddress2;
			command.Parameters.Add("@EmployeeCity", OleDbType.VarChar).Value = cm.EmployeeCity;
			command.Parameters.Add("@EmployeeState", OleDbType.VarChar).Value = cm.EmployeeState;
			command.Parameters.Add("@EmployeeZip", OleDbType.VarChar).Value = cm.EmployeeZip;
			command.Parameters.Add("@EmployeeHomePhone", OleDbType.VarChar).Value = cm.EmployeeHomePhone;
			command.Parameters.Add("@EmployeeCellPhone", OleDbType.VarChar).Value = cm.EmployeeCellPhone;
			command.Parameters.Add("@EmployeeHomeEmail", OleDbType.VarChar).Value = cm.EmployeeHomeEmail;
			command.Parameters.Add("@EmergencyContactName", OleDbType.VarChar).Value = cm.EmployeeECName;
			command.Parameters.Add("@EmergencyContactRelationship", OleDbType.VarChar).Value = cm.EmployeeECRelationship;
			command.Parameters.Add("@EmergencyContactHomePhone", OleDbType.VarChar).Value = cm.EmployeeECHomePhone;
			command.Parameters.Add("@EmergencyContactCellPhone", OleDbType.VarChar).Value = cm.EmployeeECCellPhone;
			command.Parameters.Add("@EmergencyContactWorkPhone", OleDbType.VarChar).Value = cm.EmployeeECWorkPhone;
			
			// Moved to the end and removed from the SET clause
			command.Parameters.Add("@EmployeeLastName", OleDbType.VarChar).Value = cm.LastName;
			command.Parameters.Add("@EmployeeFirstName", OleDbType.VarChar).Value = cm.FirstName;
			
			try
			{
				var numberUpdated = command.ExecuteNonQuery();                        
				MessageBox.Show("Record Updated = " + numberUpdated.ToString());
				// connection.Close(); // not needed as the connection is closed and disposed by the using block its wrapped in
			} catch (OleDbException ex)
			{
				Console.WriteLine(ex.Source);
				MessageBox.Show(ex.Source);
			}
		}
	} 
