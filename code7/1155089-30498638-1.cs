    class PurchasedItem : GroceryItem
	{
		public int Quantity { get;set; }
		public decimal Cost { get;set; }
		public PurchasedItem(string[] item)
		{
			ItemName = item[1];
			Price = decimal.Parse(item[2]);
			Quantity = int.Parse(item[3]);
			FindCost();
		}
		private void FindCost()
		{
			Cost = Price * Quantity * 1.1;
		}
	}
