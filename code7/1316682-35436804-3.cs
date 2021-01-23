    private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSymbol.Text == "Search Students")
            {
               radGridView1.DataSource = await SearchMyDataAsync(txtSymbol.Text);
            }
        }
        async Task<DataSet> SearchMyDataAsync(object state)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(MyConnectionString))
                {
                    await Task.Run(() => connection.Open()); //Or possibly connection.OpenAsync() if it exists...
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * from studenttable where studname like'" + text + "%' OR studnum like'" +
                                      text + "%' OR studcourse like'" + text + "%' OR studemail like'" + text +
                                      "%' OR studsec like'" + text + "%' OR studgender like'" + text + "%' ";
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    await Task.Run(adap.Fill(ds));
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
