 	public class Article
	{
		public decimal NormalPrice { get; set; }
		public decimal? SalePrice { get; set; }
		public bool OnSale { get; set; }
		public decimal Price
		{
			get
			{
				if (this.OnSale)
				{
					return this.SalePrice.Value;
				}
				else
				{
					return this.NormalPrice;
				}
			}
		}
	}
