            string connetionString = null;
            SqlConnection cnn ;
            SqlCommand cmd ;
            string sql = null;
            connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            sql = @"UPDATE Personal_Details 
        SET Title = '" + comboBox1.Text.Trim() + "', FIRSTNAME = '" +Txt_FirstName.Text.Trim()+ "', MIDDLENAME = '" + mIDDLENAMETextBox.Text.Trim() + "', '" + sURNAMETextBox.Text.Trim() + "', '" + cITYTextBox.Text.Trim() + "', '" + eMAILTextBox.Text.Trim() + "' WHERE PersonID = '"+personIDTextBox+"'";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"); 
            }
