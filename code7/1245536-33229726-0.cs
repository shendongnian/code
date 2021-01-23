    public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			dockingContentControl.Focus();
		}
		private void dockingContentControl_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			Console.WriteLine(e.Key);
		}
	}
