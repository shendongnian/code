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
		
		var joinedResults = fruits.Join(groceries, // References the groceries declared above,
										fruit => fruit.GroceryId,  // Join by GroceryId located on the Fruit
										grocery => grocery.GroceryId,  // Join by the GroceryID located on Grocery 
										(product, grocery) => new 
										{
											ProductId = product.ProductId, 
											ProductName = product.Name, 
											GroceryName = grocery.Name
										});
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
