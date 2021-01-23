	private bool moveAllowed = true;
	private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
	public Form1()
	{
		this.timer.Interval = 1000;
		this.timer.Tick += (s, e) =>
		{
			// this runs on the UI thread, so no locking necessary.
			this.timer.Stop(); // this call is necessary, because unlike System.Timers.Timer, there is no AutoReset property to do it automatically.
			this.moveAllowed = true;
		};
	}
		  
	// The code in this event handler runs on the UI thread.
	private void Form1_KeyDown(object sender, KeyEventArgs e)
	{
		if (this.moveAllowed)
		{
			this.moveAllowed = false;
			Movement();
			this.timer.Start(); // wait 1 second to reset this.moveAllowed to true.
		}
	}
