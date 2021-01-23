    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string constring = "datasource=localhost;port=3306;username=root;password=root";
        string Query = "SELECT * from database.check WHERE patientname IS NOT NULL";
        using(MySqlConnection conDataBase = new MySqlConnection(constring))
        using(MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase))
        {
            try
            {
                conDataBase.Open();
                using(MySqlDataReader myReader = cmdDataBase.ExecuteReader())
                {
                    int namePos = myReader.GetOrdinal("namethestore");
                    int checkerPos = myReader.GetOrdinal("checkername");
                    while (myReader.Read())
                    {
                        string namethestore = myReader.IsDBNull(namePos) 
                                              ? string.Empty 
                                              : myReader.GetString("namethestore");
                        string checkername = myReader.IsBNull(checkerPos) 
                                              ? string.Empty
                                              : myReader.GetString("checkername");
                        this.textBox65.Text = namethestore;
                        this.textBox66.Text = checkername;
                    }
               }
          }
    }
