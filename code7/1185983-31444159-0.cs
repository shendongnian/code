	public void Processor()
	{
		// ------------- SETTING UI COMPONENTS 
	
		lblProgress.Visible = true;
		progressBar.Visible = true;
		btnStop.Visible = true;
	
		// ------------- WORKING
	
		Urls
			.ToObservable(Scheduler.Default) // Goes to background thread
			.Do(url =>
			{
				/* .... WORKING THAT TAKES TIME */
			})
			.Select((url, counter) => counter * 100 / Urls.Count())
			.DistinctUntilChanged()
			.ObserveOn(this) // back to the UI thread
			.Subscribe(
				percent => // Done each change in percent
				{
					lblProgress.Text = "Progress: " + (percent > 100 ? 100 : percent) + "%";
					progressBar.Value = percent;
				},
				() => // Done when finished processing
				{
					lblProgress.Visible = false;
					progressBar.Visible = false;
					btnStop.Visible = false;
					lblDone.Visible = true;	
				});
	}
