    using (SqlConnection conn = new SqlConnection())
    {
        conn.ConnectionString = "Integrated Security=true;Initial Catalog=xyz;server=abc";
        string sqlQuery = "Select * from myTable where name like '%[\\]%' or name like '%[%]%'";
        conn.Open();
        using (SqlCommand command = new SqlCommand(sqlQuery, conn))
        {
            var result = command.ExecuteReader();
        }
    }
