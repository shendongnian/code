    try
	{
		var dlg = new System.Windows.Forms.FolderBrowserDialog();
		var result = dlg.ShowDialog(this.GetIWin32Window());
		if (result.ToString() == "OK")
		{
			var dbfileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LibraryManger.mdf");
			var backupConn = new SqlConnection { ConnectionString = eb.GetConnectionString() };
			backupConn.Open();
			var backupcomm = backupConn.CreateCommand();
			var backupdb = $@"BACKUP DATABASE ""{dbfileName}"" TO DISK='{Path.Combine(dlg.SelectedPath,"LibraryManagement.bak")}'";
			var backupcreatecomm = new SqlCommand(backupdb, backupConn);
			backupcreatecomm.ExecuteNonQuery();
			backupConn.Close();
			MessageBox.Show($"Database backup has successfully stored in {Path.Combine(dlg.SelectedPath, "LibraryManagement.bak")}", "Confirmation");
		}
	}
	catch (Exception ex)
	{
		if(ex.Message.Contains("Operating system error"))
		{
			MessageBox.Show("Please chose a public folder.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		else
			MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
	}
