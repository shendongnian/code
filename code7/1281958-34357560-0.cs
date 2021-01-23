	public partial class Form1 : Form
	{
		private BackgroundWorker _backgroundWorker;
		public Form1()
		{
			InitializeComponent();
			_backgroundWorker.DoWork += DoWork;
			_backgroundWorker.RunWorkerCompleted += WorkerCompleted;
			_backgroundWorker.WorkerReportsProgress = true;
			_backgroundWorker.ProgressChanged += WorkerProgressed;
		}
		private void buttonAdd_Click(object sender, EventArgs e)
		{
			//Adding label to panel
			MyLabel label = new MyLabel();
			label.Text = "Test";
			label.Location = new Point(0, 0);
			progressPanel.Controls.Add(label);
			//Showing progressPanel
			progressPanel.Visible = true;
			progressBar1.Minimum = 0;
			progressBar1.Maximum = 100;
			progressBar1.Value = 0;
			progressBar1.Step = 1;
            // to avoid multiple starts
			buttonAdd.Enabled = false;
            
            // start working
			_backgroundWorker.RunWorkerAsync();        
		}
		private void DoWork(object sender, DoWorkEventArgs e)
		{
			_backgroundWorker.ReportProgress(1);
			// work
			_backgroundWorker.ReportProgress(50);
			// more work
			_backgroundWorker.ReportProgress(100);
		}
		private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			progressPanel.Visible = false;
			buttonAdd.Enabled = true;
		}
		private void WorkerProgress(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}
	}
