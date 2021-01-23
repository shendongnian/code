	public class Thing 
	{
		public List<Market> Markets {get; set;}
	}
	public class Market
	{
		public Price Prices {get; set;}
	}
	public class Price
	{
		public List<AvailablePrice> AvailableToBuy {get; set;}	
	}
	public class AvailablePrice
	{
		public string Id {get; set;}
		public int Size {get; set;}
		public decimal Price {get;set;}
	}
