	public class ThreadManager()
	{
		private CancellationTokenSource cts = new CancellationTokenSource();
		
		public ThreadManager(Form form)
		{
			form.FormClosing += OnFormClosing;
		}
		
		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			cts.Cancel();
		}
	}
