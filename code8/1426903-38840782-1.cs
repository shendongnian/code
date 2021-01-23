    string connstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    DataTable ResultTable = new DataTable();
    using (SqlConnection conn = new SqlConnection(connstring))
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "";
            cmd.Parameters.Add("@UserNameIn", SqlDbType.Int).Value = txtUserName.Text; // or what eve that supplay the username
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
            sqlAdapter.Fill(ResultTable);
        }
       
    }
