	public partial class MainWindow
	{
		public MainWindow(IMainWindowViewModel vm)
		{
			InitializeComponent();
			ViewModel = vm;
		}
		public IViewModel ViewModel
		{
			get { return (IViewModel)DataContext; }
			set { DataContext = value; }
		}
	}
