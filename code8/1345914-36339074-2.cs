	void MyMenuItem_Click(object sender, RoutedEventArgs e) {
		Process p = new Process();
		p.StartInfo.FileName = "notepad.exe";
		p.StartInfo.CreateNoWindow = false;
		Title = "Waiting for Notepad to be closed.";
		executeBlocking(p, () => {
			Title = "Finished work with Notepad, you may resume your work.";
		});
	}
	void executeBlocking(Process p, Action onFinish) {
		IsEnabled = false;
		BackgroundWorker processHandler = new BackgroundWorker();
		processHandler.DoWork += (sender, e) => {
			p.Start();
			p.WaitForExit(); // block in background
			p.Close();
		};
		processHandler.RunWorkerCompleted += (sender, e) => {
			IsEnabled = true;
			onFinish.Invoke();
		};
		processHandler.RunWorkerAsync();
	}
