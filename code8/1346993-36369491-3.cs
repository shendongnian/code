	public partial class ItemsPage : ContentPage
	{
		public ItemsPage()
		{
			InitializeComponent();
			Vm = new ItemsViewModel();
			BindingContext = Vm;
		}
		protected override async void OnAppearing()
		{
			var playlist = await Vm.GetPlaylist();
            // Do something cool with the string.
		}
		public ItemsViewModel Vm { get; private set; }
	}
