            private void vehicleMakeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = null;
            string command = "SELECT * FROM Makes WHERE [Car Brand] = '" + vehicleMakeComboBox.Text + "'";
            string command2 = null;
            mainMenu.connection.Open();
            SqlCeCommand makeSearch = new SqlCeCommand(command, mainMenu.connection);
    //  This part gets the ID of the car brand they picked in the first combo box.  Ford is 1, Chevy is 2, Dodge is 3  
            SqlCeDataReader makeRead = makeSearch.ExecuteReader();
            while (makeRead.Read())
            {
                ID = (makeRead["ID"].ToString());
            }
            makeRead.Close();
            makeRead.Dispose();
            vehicleModelComboBox.Items.Clear(); // Clears the combo box incase they picked a brand and then picked another
    //  This part now selects all rows in the Model table that have the same value in the Make ID column as the car brand they chose in the first combo box  
            command2 = "SELECT * FROM Model WHERE [Make ID] = " + ID;
            SqlCeCommand modelSearch = new SqlCeCommand(command2, mainMenu.connection);
            SqlCeDataReader modelRead = modelSearch.ExecuteReader();
            while (modelRead.Read())
            {
                vehicleModelComboBox.Items.Add(modelRead["Model"]);
            }
            modelRead.Close();
            modelSearch.Dispose();
            mainMenu.connection.Close();
        }
