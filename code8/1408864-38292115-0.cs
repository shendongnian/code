	bool connect2device = false;
    private void startConnection(object sender, RoutedEventArgs e)
	{
		comm_stat.Text = "Connecting...";
		// do the handshaking operations. the result is then assigned to connect2device
		BackgroundWorker worker = new BackgroundWorker();
		worker.DoWork += DoWork;
		worker.RunWorkerCompleted += Completed;
		worker.RunWorkerAsync();
	}
		
	private void Completed(object sender, RunWorkerCompletedEventArgs e)
	{
		comm_stat.Text = connect2device ? "Succeed." : "Failed!";
	}
	private void DoWork(object sender, DoWorkEventArgs e)
	{
		//Change with actual work.
		Thread.Sleep(1000);
		connect2device = true;
	}
