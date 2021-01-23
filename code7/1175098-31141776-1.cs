	public partial class MainForm : Form
	{
		private readonly SynchronizationContext _context;
		public MainForm()
		{
			InitializeComponent();
			// the context of MainForm, main UI thread
			// 1 Application has 1 main UI thread
			_context = SynchronizationContext.Current;
		}
		private void BtnRunAnotherThreadClick(object sender, EventArgs e)
		{
			Task.Run(() =>
					 {
						 while (true)
						 {
							 Thread.Sleep(1000);
							 //lblTimer.Text = DateTime.Now.ToLongTimeString(); // no work
							 UpdateTimerInMainThread(); // work
						 }
					 });
		}
		private void UpdateTimerInMainThread()
		{
			//SynchronizationContext.Current, here, is context of running thread (Task)
			_context.Post(SetTimer, DateTime.Now.ToLongTimeString());
		}
		public void SetTimer(object content)
		{
			lblTimer.Text = (string)content;
		}
	}
