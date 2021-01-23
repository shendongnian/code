        private void SaveDetails()
        {
            string InsertNewLicense = "INSERT into BCOM.LicenseDetails(LicenseeName,ComputerName,ContactName,ContactEmail,LicenseKey,CreationDate) values(@LicenseeName, @ComputerName, @ContactName, @ContactEmail, @LicenseKey, @CreationDate)";
            string LicenseExistence = "SELECT COUNT(*) FROM BCOM.LicenseDetails WHERE LicenseKey LIKE @LicenseKey";
            
            MySqlConnection LicenseDetails = new MySqlConnection(LicenseDatabaseConnection);
            
            MySqlCommand InsertCommand = new MySqlCommand(InsertNewLicense, LicenseDetails);
            InsertCommand.Parameters.AddWithValue("@LicenseeName", this.textBoxLicenseeName.Text);
            InsertCommand.Parameters.AddWithValue("@ComputerName", this.textBoxComputerName.Text);
            InsertCommand.Parameters.AddWithValue("@ContactName", this.textBoxContactName.Text);
            InsertCommand.Parameters.AddWithValue("@ContactEmail", this.textBoxContactEmail.Text);
            InsertCommand.Parameters.AddWithValue("@LicenseKey", this.textBoxLicenseKey.Text);
            InsertCommand.Parameters.AddWithValue("@CreationDate", this.textBoxCreationDate.Text);
            
            MySqlCommand QueryCommand = new MySqlCommand(LicenseExistence, LicenseDetails);
            QueryCommand.Parameters.AddWithValue("@LicenseKey", this.textBoxLicenseKey.Text);
            MySqlDataReader InsertReader;
            LicenseDetails.Open();
            if ((int)(long)QueryCommand.ExecuteScalar() >0)
            {
                MessageBox.Show("This license already exists in the database.");
            }
            else
            {
                InsertReader = InsertCommand.ExecuteReader();
                MessageBox.Show("License Details Saved. Please ensure you have emailed the license to the customer.");
                while (InsertReader.Read())
                {
                }
            }
            LicenseDetails.Close();
