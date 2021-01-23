	private final object flagLock = new object();
	private bool moveAllowed = true;
	private System.Timers.Timer timer = new System.Timers.Timer();
	public Form1()
	{
		this.timer.Interval = 1000;
		this.timer.AutoReset = false;
		this.timer.Elapsed += (s, e) =>
		{
			// this DOES NOT run on the UI thread, so locking IS necessary to ensure correct behavior.
			this.timer.Stop();
			lock (this.flagLock) {
				this.moveAllowed = true;
			}
		};
	}
		  
	// The code in this event handler runs on the UI thread.
	private void Form1_KeyDown(object sender, KeyEventArgs e)
	{
		// Locking is necessary here too.
		lock (this.flagLock) {
			if (this.moveAllowed)
			{
				this.moveAllowed = false;
				Movement();
				this.timer.Start(); // wait 1 second to reset this.moveAllowed to true.
			}
		}
	}
