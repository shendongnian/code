	public partial class ItemsPage : ContentPage
	{
		public ItemsPage()
		{
			InitializeComponent();
			Vm = new ItemsViewModel();
			BindingContext = Vm;
		}
		protected override void OnAppearing()
		{
			ListviewItems.SelectedItem = Vm.Items[1];
		}
		public ItemsViewModel Vm { get; private set; }
