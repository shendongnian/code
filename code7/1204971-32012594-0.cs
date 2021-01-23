    private void button1_Click(object sender, EventArgs e)
		{
			int limit = 10;
			var bw = new BackgroundWorker();
			bw.WorkerReportsProgress = true;
			bw.DoWork += (s, ee) =>
			{
				for (int i = 0; i < limit; i++)
				{
					bw.ReportProgress(i);
					Thread.Sleep(1000);
				}
			};
			bw.ProgressChanged += (s, ee) => label9.Text = "Processing" + ee.ProgressPercentage.ToString();
			bw.RunWorkerAsync();
		}
    
