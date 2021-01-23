    		private void BWKamera_DoWork(object sender, DoWorkEventArgs e)
        {
		
		OleDbDataReader bacadata = (OleDbDataReader)e.Argument;
		while (bacadata.Read())
            {
                pingreply = ping.Send(bacadata["ipadd"].ToString());
