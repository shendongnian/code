	public class Product
	{
		public int ProductId { get; set; }
		public string  ProductName { get; set; }
		public string ProductPropertyOne { get; set; }
		public string ProductPropertyTwo { get; set; }
		public int ProductSortOrder { get; set; }
	}
	var grouped = products.Where(p=> p.ProductPropertyOne=="Property-A").GroupBy(p => p.ProductName).Select(grp => string.Format("<a href=\"#\" {0} > {1} </a>",
		string.Join(" ", grp.Select(v => string.Format("data-{0}=\"yes\" ",v.ProductPropertyTwo))),grp.Key)).ToList();
	var finalOutput= string.Join(Environment.NewLine, grouped);
