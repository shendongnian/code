    try
	{
		if (eb != null)
		{
			eb.DisposeConnection();
			eb = null;
		}
	
    	var dlg = new OpenFileDialog();
		dlg.InitialDirectory = "C:\\";
		dlg.Filter = "Database file (*.bak)|*.bak";
		dlg.RestoreDirectory = true;
		if (Equals(dlg.ShowDialog(), true))
		{
			using (var con = new SqlConnection())
			{
				con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=Master;Integrated Security=True;Connect Timeout=30;";
				con.Open();
				var dbfileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LibraryManger.mdf");
					using (var cmd = new SqlCommand())
					{
						cmd.Connection = con;
						cmd.CommandText = $@"RESTORE DATABASE ""{dbfileName}"" FROM DISK='{dlg.FileName}'";
						cmd.ExecuteNonQuery();
					}
					con.Close();
				}
			MessageBox.Show($"Database backup has successfully restored.", "Confirmation");
			eb = new EntityBroker.EntityBroker();
		}
	}
	catch (Exception ex)
	{
		MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
	}
