	public partial class MyActivities : ContentPage
	{
		private bool _isLoading;
		public bool IsLoading //Binded to ActivityIndicator
		{
			get { return _isLoading; }
			private set
			{
				_isLoading = value;
				OnPropertyChanged("IsLoading");
			}
		}
		public MyActivities()
		{
			BindingContext = this;
			InitializeComponent();
			btnNavitage.Clicked += async (s,a) => 
			{
				IsLoading = true;
				var animateEnd = await aiControl.FadeTo(1d); //aiControl is the ActivityIndicator, animate it do the trick
				try
				{
					await Navigation.PushAsync(new CheckInForm()); //when the code reach the PushAsync, ActivityIndicator is already running
				}
				finally
				{
					IsLoading = false;
				}
			}
		}
	}
