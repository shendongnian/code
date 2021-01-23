	private void button_go_Click(object sender, RoutedEventArgs e)
	{
		var uiContext = SynchronizationContext.Current;
		Observable
			.Create<System.Reactive.EventPattern<TestResultArgs>>(o =>
			{
				var myTest = new MyTest();
				var subscription =
					Observable
						.FromEventPattern<TestResultHandler, TestResultArgs>(
							h => myTest.Results += h,
							h => myTest.Results -= h)
						.Take(1)
						.Subscribe(o);
				myTest.Run();
				return subscription;
			})
			.ObserveOn(uiContext)
			.Subscribe(x => this.richTextBox_testResults.Document.Blocks.Add(new Paragraph(new Run(x.EventArgs.Results))));
	}
