	var tabBar = new UITabBar();
	tabBar.ItemSelected += (object sender, UITabBarItemEventArgs e) =>
	{
		Console.WriteLine($"{e.Item} has selected");
		if (e.Item.Tag == 99)
		{
			Console.WriteLine("Item with tag 99 was selected");
		}
	};
