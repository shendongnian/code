	public class ShopDatabaseEntities
	{
		public List<MyProduct> Products = new List<MyProduct>();
		public List<MyProductProperty> ProductProperties = new List<MyProductProperty>();
		public List<MyProperty> Properties = new List<MyProperty>();
	}
	
	public class MyProduct
	{
		public int ProductId;
		public string Name;
		public string ProductName;
		public decimal ProductPrice;
		public List<MyProperty> pros = new List<MyProperty>();
	}
	
	public class MyProductProperty
	{
		public int ProductId;
		public int PropertyId;
		public double PropertyValue;
	}
	
	public class MyProperty
	{
		public int PropertyId;
		public string PropertyName;
		public double PropertyValue;
	}
