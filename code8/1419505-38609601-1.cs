	private List<Action> jobs = new List<Action>();
	private object jobsLock = new object();
	
    // This is the CPU-intensive function that does the actual work of checking passwords
	private void TestPasswords(int length) {
		for(int i = 0; i < (1 << length); i++)
		{
			// Simulate testing the password.
			Thread.Sleep(100);
		}
	}
	
    // Each thread is dispatched with this action.
    // It keeps pulling jobs from the queue and executing them until no more remain.
	private void DoWork()
	{
		while(true)
		{
			Action job = null;
			lock(this.jobsLock)
			{
				if(this.jobs.Count == 0)
				{
					return;
				}
				
				job = this.jobs[0];
				this.jobs.RemoveAt(0);
			}
			
			if(job != null)
			{
				job();
			}
		}
	}
	
    // Tester method
	public void Run()
	{
        // For all password lengths from 1 to 8, generate a job to test passwords.
        // You probably want to divide these differently (e.g. let i be the job that tests
        // all 1 - 8 character passwords starting with the character i, such that
        // all jobs are approximately of equal length).
		for(int i = 1; i <= 8; i++)
		{
			int length = i;
			this.jobs.Add(() => TestPasswords(length));
		}
		
        // Create a background thread for each of the cores except one, 
        // and let them execute the DoWork loop until the queue is empty.
        // You may build a ContinueWith or WaitAll mechanism to catch the results
        // and build some callback stuff to get the progress.
		int numberOfCores = 8;
		for(int i = 0; i < numberOfCores - 1; i++)
		{
			Task.Run(DoWork);
		}
	}
