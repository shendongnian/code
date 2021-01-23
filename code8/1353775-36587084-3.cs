	private void button_go_Click(object sender, RoutedEventArgs e)
	{
		var uiContext = SynchronizationContext.Current;
		Observable
			.Create<System.Reactive.EventPattern<TestResultArgs>>(o =>
			{
				var subscription =
					Observable
						.FromEventPattern<TestResultHandler, TestResultArgs>(
							h => this.myTest.Results += h,
							h => this.myTest.Results -= h)
						.Take(1)
						.Subscribe(o);
				this.runningTest = new Task(() => { this.myTest.Run(); });
				this.runningTest.Start();
				return subscription;
			})
			.ObserveOn(uiContext)
			.Subscribe(x => this.richTextBox_testResults.Document.Blocks.Add(new Paragraph(new Run(x.EventArgs.Results))));
	
		// block on purpose, wait for the task to finish
		this.runningTest.Wait();
	}
