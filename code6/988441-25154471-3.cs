    using (SqlConnection conn = new SqlConnection(connstring))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT Column1, Column2 FROM Table WHERE Column1=@col1 AND Column2 > @col2 ORDER BY Column1, Column2 " , conn))
        {
            cmd.Parameters.AddWithValue("@col1", str);
            cmd.Parameters.AddWithValue("@col2", val);
            using(var reader = cmd.ExecuteReader())
            {
                //...
            }            
        }
    }    
        
