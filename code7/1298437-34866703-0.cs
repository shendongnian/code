    private void enterNewVehcileForm_Load(object sender, EventArgs e)
        {
            vinAutoPopulateTextBox.Text = mainMenu.VIN;
            mainMenu.connection.Open();
            SqlCeCommand cs = new SqlCeCommand("SELECT * FROM Makes", mainMenu.connection);
            SqlCeDataReader dr = cs.ExecuteReader();
            while (dr.Read())
            {
                vehicleMakeComboBox.Items.Add(dr["Car Brand"]);
            }
            
            dr.Close();
            dr.Dispose();           
            mainMenu.connection.Close();
        }
