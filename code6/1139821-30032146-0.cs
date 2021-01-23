    using (SqlConnection conn = new SqlConnection(yourConnectionString))
    {
        SqlCommand command = new SqlCommand();
        command.Connection = conn;
        command.CommandType = CommandType.Text;
        command.CommandText = "select column, column2 from table where column=@column";
        command.Parameters.Add(new SqlParameter("column", SqlDbType.VarChar, 50));
        command.Parameters["column"].Value = yourColumnValue;
        conn.Open();
        using (SqlDataReader sdr = sco.ExecuteReader())
        {
            GridView2.DataSource = sdr;
            GridView2.DataBind();
        }
    }  
