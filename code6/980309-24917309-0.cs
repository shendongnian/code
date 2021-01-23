    protected void Button3_Click(object sender, EventArgs e)
    {
        string cmdText = "SELECT TOP @Count * FROM qb_vb WHERE marks=1";
    
        using (var cnn = new SqlConnection(CONNECTION_STRING))
        {
            var cmd = new SqlCommand(cmdText, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Count", Label4.Text);
    
            cnn.Open();
    
            SqlDataReader dr1 = cmd.ExecuteReader();
    
            if (dr1.Read())
            {
                Label8.Text = dr1["quest"].ToString();
                Label9.Text = dr1["ans1"].ToString();
            }
        }
    }
