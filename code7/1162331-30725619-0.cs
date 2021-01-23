    using (OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        {
           OleDbCommand cmd = new OleDbCommand("INSERT INTO DB1 (message) values (@message)");
           cmd.Connection = conn;
           conn.Open();
           cmd.Parameters.Add("@message", OleDbType.VarChar).Value = txtpost.text.Trim();
           cmd.ExecuteNonQuery();
           conn.Close();
        }
