    	private MenuItem[] InitializeMenu()
		{
			MenuItem One = new MenuItem("One");
			One.RadioCheck = true;
			One.Checked = true;
			MenuItem Two = new MenuItem("Two");
			Two.RadioCheck = true;
			MenuItem Three = new MenuItem("Three");
			Three.RadioCheck = true;
			One.Checked = true;
			MenuItem[] menu = new MenuItem[] {
				new MenuItem("About", menuAboutClick),
				One,
				Two,
				Three,
				new MenuItem("Exit", menuExitClick)
			};
			return menu;
		}
