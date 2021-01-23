    string connString = @"database=Agenda_db; Data Source=Marian-PC\SQLEXPRESS; Persist Security Info=false; Integrated Security=SSPI";
    SqlConnection conn = new SqlConnection(connString);
    SqlCommand myCommand = new SqlCommand(("SELECT * FROM Contact;"+ "SELECT * FROM Numar_contact",conn);
    SqlDataReader myReader ;
    
    int RecordCount=0; 
    
    try
    {
        myConnection.Open();
        myReader = myCommand.ExecuteReader();
    
        while (myReader.Read())
        {
            //Write logic to process data for the first result.
             RecordCount = RecordCount + 1;
        }
        MessageBox.Show("Total number of Contacts: " + RecordCount.ToString());
    
        myReader.NextResult();   // <<<<<<<<<<< MOVE TO NEXT RESULTSET
        RecordCount = 0;
    
        while (myReader.Read())
        {
            //Write logic to process data for the second result.
            RecordCount = RecordCount + 1;
        }
        MessageBox.Show("Total number from Numar_contacts: " + RecordCount.ToString());
    }
    catch(Exception ex) 
    {
       MessageBox.Show(ex.ToString());
    }
    finally
    {
        conn.Close(); // Could be replaced with  using statement too
    }
