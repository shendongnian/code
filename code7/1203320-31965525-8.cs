    DataTable dt = new DataTable();
    dt.Columns.Add("Col1", typeof(int));
    dt.Columns.Add("Col2", typeof(string));
    // Fill your data table here
    using (var con = new SqlConnection("ConnectionString"))
    {
        using(var cmd = new SqlCommand("MyProcedure", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MyTable", SqlDbType.Structured).Value = dt;
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
