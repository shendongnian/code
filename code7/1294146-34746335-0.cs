    public partial class MainWindow : Window
	{
		private readonly MySynchronizationContext _synchronizationContext;
		public MainWindow()
		{
			InitializeComponent();
			_synchronizationContext = new MySynchronizationContext(SynchronizationContext.Current);
			
        }
		private void button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				_synchronizationContext.Send(
					x =>
					{
						DoSomethingOnUiThreadThatThrowsException();
					}, null);
			}
			catch (Exception)
			{
				Debug.WriteLine("Catched Exception in thread that calles Send-Method.");
				throw;
			}
		}
		private static void DoSomethingOnUiThreadThatThrowsException()
		{
			throw new Exception("Any Exception...");
		}
	}
    class MySynchronizationContext
	{
		SynchronizationContext innerContext;
		public MySynchronizationContext(SynchronizationContext ctx)
		{
			innerContext = ctx;
		}
		public virtual void Send(SendOrPostCallback d, object state)
		{
			Exception threadException = null;
			try
			{
				innerContext.Send(_ =>
				{
					try
					{
						d.Invoke(state);
					}
					catch (Exception exception)
					{
						threadException = exception;
					}
				}, null);
			}
			catch (Exception ex)
			{
			}
			if (threadException != null)
			{
				throw new Exception("Synchronization error", threadException);
			}
		}
	}
