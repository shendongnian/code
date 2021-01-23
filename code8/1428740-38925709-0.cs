	public class Product
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public bool Discontinued { get; set; }
		public Category Category { get; set; }
	}
	public class Category
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
	}
