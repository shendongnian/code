    private void button_go_Click(object sender, RoutedEventArgs e)
    {
        var uiContext = SynchronizationContext.Current;
        var results = Observable.FromEventPattern<TestResultHandler, TestResultArgs>(
            handler => (s, a) => handler(s, a),
            handler => this.myTest.Results += handler,
            handler => this.myTest.Results -= handler)
			.Take(1)
            .ObserveOn(uiContext)
            .Subscribe(x => this.richTextBox_testResults.Document.Blocks.Add(new Paragraph(new Run(x.EventArgs.Results))));
        // start running the test
        this.runningTest = new Task(() => { this.myTest.Run(); });
        this.runningTest.Start();
        // block on purpose, wait for the task to finish
        this.runningTest.Wait();
    }
