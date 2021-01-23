     private void btnSaveDetails_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = (Properties.Settings.Default.BioEngineering);
            sc.Open();
            com.Connection = sc;
            com.CommandText = ("INSERT INTO Users (Forename, Surname, Company, SecurityLevel, IssueDate, ExpiryDate, CardID) VALUES ('" + this.txtFirstName.Text + "','" + this.txtLastName.Text + "','" + this.txtCompany.Text + "','" + this.cboSecurityLevel.Text + "','" + this.dtpIssueDate.Value.ToString("MM/dd/YYYY") + "','" + this.dtpExpiryDate.Value.ToString("MM/dd/YYYY") + "','" + this.cboCardID.Text + "');");
    
            com.ExecuteNonQuery();
            sc.Close();
        }
