	//used to be a counter for your progress
	int i_counter = 0;
	
	//create  a background worker instance
    public BackgroundWorker bg_worker = new BackgroundWorker();
    public Form1()
    {
        InitializeComponent();
        //set this to true if you want to have an event where you can cancel the background task
        bg_worker.WorkerSupportsCancellation = true;
        //this is needed to actually show your progress, allows the background worker to report it is working
        bg_worker.WorkerReportsProgress = true;
        //assigns the "DoWork" and "ProgressChanged" Handlers to the background worker.
        bg_worker.DoWork += new DoWorkEventHandler(bg_worker_DoWork);
        bg_worker.ProgressChanged += new ProgressChangedEventHandler(bg_worker_ProgressChanged);
    }
    //Mail method
    public void MailerMethod()
    {
        //all of the things you want to happen for your mailing methods
		
		foreach(//your loop stuff in here)
        {
			//THIS NEEDS TO HAPPEN TO CAUSE THE COUNTER TO UPDATE
            bg_worker.ReportProgress(i_counter);
        }
    }
    //the stuff that you want done in the background
    //fires when "RunAsync" is called by BackgroundWorker object.
    private void bg_worker_DoWork(object sender, DoWorkEventArgs e)
    {
        //IN HERE IS WHERE YOU WANT YOUR EMAIL STUFF TO HAPPEN
		bg_worker = sender as BackgroundWorker;
		MailerMethod();//or just all of your mailing code, it looks nicer like this though
		
    }
    //fires when worker reports the progress has changed
	//caused by "ReportProgress" method
    private void bg_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        lb_counter.Text = Convert.ToString(i_counter);
    }
	
	  //this is what will happen when the worker is done.
	  //you can have it do a alot of things, such as write a report, show a window, etc.
    private void bg_worker_RunWorkComplete(object sender, RunWorkerCompletedEventArgs e)
    {
        MessageBox.Show("DONE!", "DING DING!");
		Application.Exit();
    }
    //button click event to start this shindig
    private void bt_start_Click(object sender, EventArgs e)
    {
        //makes sure the background worker isn't already trying to run
		if (!bg_worker.IsBusy)
        {
            //calls the DoWork event
			bg_worker.RunWorkerAsync();
            bt_start.Visible = false;
        }
    }
