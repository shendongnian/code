    selClient = comboBox1.SelectedItem.ToString();
    string cmdText = "Select [Tax EIN] From [TblClientInfo] Where [Client Name] = '@client';";
    //whenever I see a "cmd2", I wonder about "cmd1"... that you could probably get this into a single call into the database
    using (var conn = new SqlConnection("connection info"))
    using (var cmd2 = new SqlCommand(cmdText, conn))
    {
        //guessing a parameter type/length here. Use exact type from your DB.
        cmd2.Parameters.Add("@client", SqlDbType.NVarChar,50).Value = selClient;
        conn.Open();
        var rd = cmd2.ExecuteReader();
        while (rd.Read())
        {
            MessageBox.Show(String.Format("{0}", rd[0]));
        }
        //The main point of a using block with SqlConnection is that is safely closes the connection for you
    }
