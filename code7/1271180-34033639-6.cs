    using (var connection = new SqlConnection("some connection string"))
    {
        connection.Open();
    
        string cmd = "select * from testable where testcolumn = @testvalue";
    
        using (var command = new SqlCommand(cmd,connection))
        {
            command.Parameters.AddWithValue("testvalue",somevalue);
    
            //execute query and return data in a datatable or yield return objects
        }
    
        connection.Close();
    }
