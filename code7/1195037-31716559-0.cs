	void Main()
	{
		var fruits = new List<Fruit>
		{
			new Fruit{ GroceryId = 1,Name = "Apple", ProductId = 1},
			new Fruit{ GroceryId = 1,Name = "Orange", ProductId = 2},
		};
		
		var groceries = new List<Grocery>
		{
			new Grocery { GroceryId = 1, Name = "Fruits and Vegetables" },
			new Grocery { GroceryId = 2, Name = "Drinks and snacks" },
		};
		
		fruits.Join(groceries, fruit => fruit.GroceryId, grocery => grocery.GroceryId, (gro, res) => gro);
	}
	
	public class Fruit
	{
		public int ProductId { get; set; }
		public int GroceryId { get; set; }
		public string Name { get; set; }
	}
	
	public class Grocery
	{
		public int GroceryId { get; set; }
		public string Name { get; set; }
	}
