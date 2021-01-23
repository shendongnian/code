		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Task.Factory.StartNew(CallLengthyDllMethod);
		}
		private void CallLengthyDllMethod()
		{
			Thread.Sleep(10000); // simulating lengthy operations
			MessageBox.Show("Done!");
		}
