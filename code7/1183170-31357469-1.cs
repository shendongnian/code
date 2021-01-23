    DataSet ds = new DataSet();
    try
    {
        using (SqlConnection con = new SqlConnection(@"Data Source = sql\db1,5000; 
               Initial Catalog = uatdb; Integrated Security = SSPI"))
        using (SqlDataAdapter da = new SqlDataAdapter("usp_checkstatus", con))
        {
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(TextBox1.Text);
            da.Fill(ds);
            return ds;
        }
    }
