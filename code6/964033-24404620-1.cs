        private void button2_Click(object sender, System.EventArgs e)
		{
			
			DatabaseParam DBParam = new DatabaseParam();
			DBParam.DatabaseName = textBox1.Text;
			
            //Assign Data file parameters
			DBParam.DataFileGrowth = "10%";
			DBParam.DataFileName = textBox3.Text;
			DBParam.DataFileSize = "2";//2MB at the init state
			DBParam.DataPathName = textBox2.Text;
			//Assign Log file parameters
			DBParam.LogFileGrowth = "10%";
			DBParam.LogFileName = textBox10.Text;
			DBParam.LogFileSize = "1";//1MB at the init state
			DBParam.LogPathName = textBox11.Text;
			
			CreateDatabase(DBParam);
		}
        private void CreateDatabase(DatabaseParam DBParam)
		{
			System.Data.SqlClient.SqlConnection tmpConn;			
			string sqlCreateDBQuery;
			tmpConn = new SqlConnection();
			tmpConn.ConnectionString = "SERVER = " + DBParam.ServerName + "; DATABASE = master; User ID = sa; Pwd = sa";												
			
			sqlCreateDBQuery =	  " CREATE DATABASE " + DBParam.DatabaseName + " ON PRIMARY "
								+ " (NAME = " + DBParam.DataFileName +", " 
								+ " FILENAME = '" + DBParam.DataPathName +"', "
								+ " SIZE = 2MB,"
								+ "	FILEGROWTH =" + DBParam.DataFileGrowth  +") "
								+ " LOG ON (NAME =" + DBParam.LogFileName +", "
								+ " FILENAME = '" + DBParam.LogPathName + "', "
								+ " SIZE = 1MB, "								
								+ "	FILEGROWTH =" + DBParam.LogFileGrowth  +") ";	
	
			SqlCommand myCommand = new SqlCommand(sqlCreateDBQuery, tmpConn);			
			try
			{
				tmpConn.Open();
				MessageBox.Show(sqlCreateDBQuery);
				myCommand.ExecuteNonQuery();				
				
				MessageBox.Show("Database has been created successfully!", "Create Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Create Database", MessageBoxButtons.OK, MessageBoxIcon.Information);				
			}
			finally
			{	
				tmpConn.Close();				
			}			
			return;		
		}
        private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			textBox3.Text = textBox1.Text + "_Data";
			textBox10.Text = textBox1.Text + "_Log";			
		}
