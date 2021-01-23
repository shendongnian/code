    ConnectingProgressBar pb = new ConnectingProgressBar();
    pb.Show();
    BackgroundWorker bwConn = new BackgroundWorker();
    bwConn.DoWork += (sender, e) =>
    {
        db = new OracleConnection(defaultConnectionString);
        db.Open();
    };
    bwConn.RunWorkerCompleted += (sender, e) =>
    {
        pb.Close();
        pb.Dispose();
    };
    bwConn.RunWorkerAsync();
    return db.State;
