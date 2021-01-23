        	private void RefreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
        		string connString;//WHAT EVER IT IS
        		string Query=string.Format(@"SELECT QUESTION FROM Questions WHERE CategoryID = '{0}'",CategoryID);
                  SqlConnection connection = new SqlConnection(connString);
                  SqlCommand cmd = new SqlCommand(Query, connection);
        connection.Open();
     cmd.ExecuteNonQuery();
                  SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd,connString);
        		  
                  DataTable DataTable=new DataTable();
                 dataAdapter.Fill(DataTable);
        		 datagridview1.DataSource=DataTable;
            }
            catch (Exception)
            {
                  MessageBox.Show("ERROR WHILE CONNECTING WITH DATABASE!");
            }
        	catch	(SqlException)
        	{
        	MessageBox.Show("SqL Error!");
        	
        	}
        }
