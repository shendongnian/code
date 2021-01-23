    async Task Progress()
	{
		  await Task.Run(() =>
		  {
			   //A random threadpool thread executes the following:
			   while (!complete)
			   {
					if (fileProgress != 0 && totalProgress != 0)
					{ 
						//Here you signal the UI thread to execute the action:
						fileProgressBar.Invoke(() => 
						{ 
							//This is done by the UI thread:
							fileProgressBar.Value = (int)(fileProgress / totalProgress) * 100 
						});
					}
			   }
		  });
	}
	private async void startButton_Click(object sender, EventArgs e)
	{
		  await Copy();
		  await Progress();
		  MessageBox.Show("Done");  //here we're on the UI thread.
	}
	async Task Copy()
	{
		//You need find an async API for file copy, and System.IO has a lot to offer.
		//Also, there is no reason to create a Task for MyAsyncFileCopyMethod - the UI
		// will not wait (blocked) for the operation to complete if you use await:
		await MyAsyncFileCopyMethod();
		complete = true;
	}
 
