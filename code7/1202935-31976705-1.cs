	private void Form1_Load(object sender, EventArgs e)
	{
		var mre = new System.Threading.ManualResetEvent(initialState: false);
		System.Threading.SynchronizationContext.Current.Post(_ => 
			mre.Set(), null);
		mre.WaitOne();
		MessageBox.Show("We never get here");
	}
