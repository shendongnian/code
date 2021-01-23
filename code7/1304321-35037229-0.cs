    SqlConnection myConn = new SqlConnection ("Server=localhost;Integrated security=SSPI;database=master");
    String sql = "CREATE DATABASE MyDatabase";
    SqlCommand myCommand = new SqlCommand(sql, myConn);
    try {
        myConn.Open();
		myCommand.ExecuteNonQuery();
		// OK
    } catch (System.Exception ex) {
		// failed
    } finally {
		if (myConn.State == ConnectionState.Open) {
		    myConn.Close();
		}
	}
