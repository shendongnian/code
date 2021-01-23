	public class MenuItemViewModel : ViewModelBase
	{
		public string Header {get; set;}
		public object Content {get; set;}
		public MenuItemViewModel[] Children { get; set; }
	}
