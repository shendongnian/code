    ConnectingProgressBar pb = new ConnectingProgressBar();
    BackgroundWorker bwConn = new BackgroundWorker();
    bwConn.DoWork += (sender, e) =>
    {
        db = new OracleConnection(defaultConnectionString);
        db.Open();
    };
    bwConn.RunWorkerCompleted += (sender, e) =>
    {
        if (e.Error != null)
        {
            // An exception was thrown, handle accordingly
        }
        pb.Close();
        pb.Dispose();
    };
    bwConn.RunWorkerAsync();
    pb.ShowDialog();
    return db.State;
