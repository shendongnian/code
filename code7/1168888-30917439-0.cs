	class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		
		public Variation variation { get; set; }
		public string VariationName { get { return variation.VariationName; } }
	}
	class variation 
	{
		public string name { get; set; }
	}
