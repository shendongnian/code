            dbConn = new OleDbConnection();
            dbConn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" 
               + ch + openFileDialog1.FileName + ch;
            dbConn.Open();
            sql = "UPDATE " + this.comboBox1.SelectedItem.ToString() 
               + " SET LeagueName = @leagueName, ConferenceName = @conferenceName, 
               DivisionName = @divisionName WHERE TeamName = @teamName AND TeamYear BETWEEN @begYear AND @endYear";
            dbCmd = new OleDbCommand(sql, dbConn);
            for (int i = teamYear; i <= endYear; i++)
            {
                dbCmd.Parameters.AddWithValue("@leagueName", league);
                dbCmd.Parameters.AddWithValue("@conferenceName", conference);
                dbCmd.Parameters.AddWithValue("@divisionName", division);
                dbCmd.Parameters.AddWithValue("@teamName", this.textBoxTeamName.Text);
                dbCmd.Parameters.AddWithValue("@begYear", int.Parse(this.textBoxBegYear.Text));
                dbCmd.Parameters.AddWithValue("@endYear", int.Parse(this.textBoxBegYear.Text));
                dbCmd.ExecuteNonQuery();
            }
            dbCmd.Connection.Close();
            dbConn.Close();
