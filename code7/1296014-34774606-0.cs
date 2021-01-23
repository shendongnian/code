    public sealed partial class MainPage : Page
	{
		public LoginViewModel Login
		{
			get
			{
				return Locator.Login;
			}
		}
	 
		public MainPage()
		{
			InitializeComponent();
		}
	}
