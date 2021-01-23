        SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        
        cmd.CommandText = "StoredProcedureName";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = sqlConnection1;
        //If your procedure has parameters you can add parameters too
        //cmd.Parameters.AddWithValue("parameter", "value");
        
        sqlConnection1.Open();
        
        reader = cmd.ExecuteReader();
        // Data is accessible through the DataReader object here.
        
        sqlConnection1.Close();
