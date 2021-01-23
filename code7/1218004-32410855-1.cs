	var ItemList = new List<Selectable>()
	{
		new Selectable() { IsSelected = true },
		new Selectable() { IsSelected = false },
	};
	
	var selectedItems = ItemList.SelectedItems().ToList();
	
	Console.WriteLine(selectedItems[0].IsSelected);
	
	ItemList[0].IsSelected = false;
	Console.WriteLine(selectedItems[0].IsSelected);
