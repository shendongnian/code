    using(var con=new SqlConnection(connectionString))
    using(var command=new SqlCommand(sql,con))
    {
        con.Open();
        using(var reader=command.ExecuteReader())
        {
        ....
        }
    }
