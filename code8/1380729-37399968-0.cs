	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			loginDone.Clicked += OnLoginClick;
		}
		async void OnLoginClick(object sender, EventArgs e)
		{
			// If Login is complete/successful - set new root page
            if (YourLoginMethod()) {
   			    Application.Current.MainPage = new MainApplicationPage();
			    // Pops all but the root Page off the navigation stack, with optional animation.
			    await Navigation.PopToRootAsync(true);
            }
		}
	}
