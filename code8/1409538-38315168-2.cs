    private void button7_Click(object sender, EventArgs e)
    {
        try
        {
            s = "SELECT ID, Name FROM c03.tbl_kit t;";
            using(MySqlConnection cnn = new MySqlConnection(connectionstring))
            using(MySqlCommand mcd = new MySqlCommand(s, cnC03))
            {
                cnC03.Open();
                using(MySqlDataReader mdr = mcd.ExecuteReader())
                {
                    DataTable dt = new DataTable("DataTable1");
                    dt.Load(mdr);            
                    .... use your table ....
                    .... or add it to the global dataset
                    .... of course this means that you haven't done it manually before
                    dataSet4.Tables.Add(dt);
                    
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
