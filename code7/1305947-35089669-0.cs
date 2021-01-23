    OleDbDataReader bacadata = command.ExecuteReader();
	BWKamera.WorkerReportsProgress = true;
	BWKamera.DoWork += BWKamera_DoWork;
	BWKamera.ProgressChanged += BWKamera_ProgressChanged;
    BWKamera.RunWorkerAsync(bacadata);
