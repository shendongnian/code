        private void OnLoad(object sender, EventArgs e)
        {
        	dbConn.ConnectionString = Properties.Settings.Default.dbConnectionString;
    
    	try
    	{
    		dbConn.Open();
    		adTracks = new OleDbDataAdapter("Select * from Tracks", dbConn));
    		adTracks.Fill(dataset,"Tracks");	
    	}
    	catch (Exception err)
    	{
    		MessageBox.Show(err.Message);
    		return;
    	}
    	finally
    	{
    		dbConn.Close();
    	}
    
    	cboOriginal.DataSource = dataset.Tables["Tracks"];
    	cboOriginal.DisplayMember = "FullTitle";
    	cboOriginal.ValueMember = "ID";
    	cboOriginal.SelectedIndex = -1;
    
    	adTracks.RowUpdated += new OleDbRowUpdatedEventHandler(OnRowUpdated);
    }
