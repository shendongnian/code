    SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader reader;
    
    cmd.CommandText = "GetInvoice";
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Connection = sqlConnection1;
    
    sqlConnection1.Open();
    
    reader = cmd.ExecuteReader();
    // Data is accessible through the DataReader object here.
    
    sqlConnection1.Close();
