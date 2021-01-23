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
            // Do something cool with the string, maybe some data binding.
		}
        // Public for data binding.
		public ItemsViewModel Vm { get; private set; }
	}
