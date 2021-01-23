    string sql = "SELECT [Option] FROM Table WHERE Category = @Category";
    using (SqlConnection con = new SqlConnection(dc.Con)) {
        using (SqlCommand cmd= new SqlCommand(sql, con)) {
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = txtFirstName.Text;
            con.Open();
            var results = cmd.ExecuteReader();
        }
    }
