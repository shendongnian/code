    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        if (txtSymbol.Text == "Search Students")
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(searchMyData);
            Thread t = new Thread(pts);
            t.Start(txtSymbol.Text);
        }
     }
    public void searchMyData(object state)
    {
        try
        {
            string text = state.ToString();
            using (MySqlConnection connection = new MySqlConnection(MyConnectionString))
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * from studenttable where studname like'" + text + "%' OR studnum like'" + text + "%' OR studcourse like'" + text + "%' OR studemail like'" + text + "%' OR studsec like'" + text + "%' OR studgender like'" + text + "%' ";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                radGridView1.Invoke(new Action(() => { radGridView1.DataSource = ds }));
            }
        }
        catch(Exception ex) { }
    }
