        var n = Session["invoiceno"] != null ? Convert.ToInt32(Session["invoiceno"]) : 0;
        
    using (var conn = new SqlConnection(CONN_STR))
    {
        conn.Open();
        var sql = "SELECT * FROM invoicetable WHERE orderno = @n";
        var cmd = new SqlCommand(sql);
        cmd.Connection = conn ;
        cmd.Parameters.AddWithValue("@n", n);
        
        using(var dr = cmd.ExecuteReader())
        {
            while(dr.Read())
            {
                //loop through DataReader
            }
            dr.Close();
        }
    }
