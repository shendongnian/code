    private void btnSave_Click(object sender, EventArgs e)
            {
                AddNames(txtFirstname.Text, txtLastName.Text);
                txtFirstName.Clear();
                txtLastName.Clear();
            }
    
    
            public void AddNames(string strFirstName, string strLastName)
            {
                String connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BasqueNames.mdf;Integrated Security=True";
    
                using(SqlConnection oCON = new SqlConnection(connString))
               {
                SqlCommand oCMD = new SqlCommand("usp_BasqueNames_Insert",oCon);
        oCMD.CommandType = CommandType.StoredProcedure;
    
                oCMD.Parameters.Add("@First", SqlDbType.Nchar).Value = strFirstName;
                oCMD.Parameters.Add("@Last", SqlDbType.Nchar).Value = strLastName;
    
                oCMD.ExecuteNonQuery();
                }
            }
