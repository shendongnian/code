	// best practice - use meaningful method names
	private void buttonSaveEmployee_Click(object sender, EventArgs e)
	{
		// best practice - wrap all database connections in a using block so they are always closed & disposed even in the event of an Exception
		// best practice - retrieve the connection string by name from the app.config or web.config (depending on the application type) (note, this requires an assembly reference to System.configuration
		using(SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionName"].ConnectionString))
		{
			// best practice - use column names in your INSERT statement so you are not dependent on the sql schema column order
			// best practice - always use parameters to avoid sql injection attacks and errors if malformed text is used like including a single quote which is the sql equivalent of escaping or starting a string (varchar/nvarchar)
			// best practice - give your parameters meaningful names just like you do variables in your code
			SqlCommand sc = new SqlCommand("INSERT INTO employee (FirstName, LastName, DateOfBirth /*etc*/) VALUES (@firstName, @lastName, @dateOfBirth /*etc*/)", con);
			
			// best practice - always specify the database data type of the column you are using
			// best practice - check for valid values in your code and/or use a database constraint, if inserting NULL then use System.DbNull.Value
			sc.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar, 200){Value = string.IsNullOrEmpty(textBoxFirstName.Text) ? (object) System.DBNull.Value : (object) textBoxFirstName.Text});
			sc.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar, 200){Value = string.IsNullOrEmpty(textBoxLastName.Text) ? (object) System.DBNull.Value : (object) textBoxLastName.Text});
			
			// best practice - always use the correct types when specifying your parameters, in this case a string is converted to a DateTime type before being assigned to the SqlParameter.Value
			// note - this is not a very robust way to parse a date as the user is never notified in the event of failure, the purpose here is simply to show how to parameters of various types
			DateTime dob;
			sc.Parameters.Add(new SqlParameter("@dateOfBirth", SqlDbType.Date){Value = DateTime.TryParse(textBoxDateOfBirth.Text, out dob) ? (object) dob : (object) System.DBNull.Value});
			// best practice - open your connection as late as possible unless you need to verify that the database connection is valid and wont fail and the proceeding code execution takes a long time (not the case here)
			con.Open();
			int o = sc.ExecuteNonQuery();
			MessageBox.Show(o + ":Record has been inserted");
			
			// the end of the using block will close and dispose the SqlConnection
			// best practice - end the using block as soon as possible to release the database connection
		}
	}
