        string Query = "UPDATE FullInk SET InStock = '" + newSum + "' Where Catalog = '" + catalog + "'";
        SqlConnection connection = new SqlConnection(conString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(Query, sql_con);
        cmd.ExecuteNonQuery();    
        connection.Close(); 
