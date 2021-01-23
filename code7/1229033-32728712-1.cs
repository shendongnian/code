	public class DemoViewModel : ViewModelBase
	{
		public MenuItemViewModel[] MenuItems {get; set;}
		
		public DemoViewModel()
		{
			this.MenuItems = new MenuItemViewModel[]
			{
				new MenuItemViewModel{
					Header = "File", Content="icon.png",
					Children = new MenuItemViewModel[]
					{
						new MenuItemViewModel{Header="Open", Content="icon.png"},
						new MenuItemViewModel{Header="Save", Content="icon.png"},
						new MenuItemViewModel{Header="Close", Content="icon.png"},
					}
				},
				new MenuItemViewModel{
					Header = "Edit", Content="icon.png",
					Children = new MenuItemViewModel[]
					{
						new MenuItemViewModel{Header="Cut", Content="icon.png"},
						new MenuItemViewModel{Header="Copy", Content="icon.png"},
						new MenuItemViewModel{Header="Paste", Content="icon.png"},
					}
				}
			};
		}
	}
