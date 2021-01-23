	class UtilityClass
	{
		public event EventHandler<ProgressChangedEventHandler> ProgressChanged;
		public class ProgressChangedEventHandler : EventArgs
		{
			public int Progress
			{
				get;
				private set;
			}
			public ProgressChangedEventHandler(int progress)
			{
				Progress = progress;
			}
		}
		public void DoWork()
		{
			for (int i = 0; i < 100; i++)
			{
				Thread.Sleep(300);
				if (ProgressChanged != null)
					ProgressChanged(this, new ProgressChangedEventHandler(i));
			}
		}
	}
