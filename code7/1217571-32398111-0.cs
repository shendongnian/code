        private void findCommand(string command)
		{            
			string MyConnection = "datasource=" + ipaddress + ";username=" + username + ";password=" + password + "";
			string Query = "select * from discordsongrequest.commands where command = '" + command + "';";
			MySqlConnection MyConn = new MySqlConnection(MyConnection);
			MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
			MyConn.Open();
			MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
			MyAdapter.SelectCommand = MyCommand;
			DataTable dTable = new DataTable();
			MyAdapter.Fill(dTable);
			
			dgvMySqlKBer.Invoke((MethodInvoker)delegate
            {
				dgvMySqlKBer.DataSource = dTable;
            });			
			
			dgvMySqlKBer.DataSource = dTable;
			MyConn.Close();
		}
