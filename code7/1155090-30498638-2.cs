    Main()
	{
		string[] groceryItems = System.IO.File.ReadAllLines(@"C:\C\groceries.txt");
		var purchasedItems = new List<PurchasedItem>();
		foreach (var item in groceryItems)
		{
			string[] line = item.Split(',');
			purchasedItems.Add(new PurchasedItem(line));
		}
	}
