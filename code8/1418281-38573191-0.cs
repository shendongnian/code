	public static void Main()
	{
		var guitars = new List<Guitar>()
		{
			new Guitar(){ Brand = "Fender", Status = Status.Sold },
			new Guitar(){ Brand = "Fender", Status = Status.InStock },
			new Guitar(){ Brand = "Gibson", Status = Status.InStock },
			new Guitar(){ Brand = "Gibson", Status = Status.InStock }
		};
		var query = guitars
						.GroupBy(guitar => guitar.Brand)
						.Select(group => new 
						{ 
							GuitarBrand = group.Key, 
							Sold = group.Where(guitar => guitar.Status == Status.Sold).Count(),
							Total = group.Count()
						})
						.Select(_ => new 
						{
							_.GuitarBrand,
							PercentSold = ((decimal)_.Sold / (decimal)_.Total) * 100,
							SoldAndTotal = string.Format("{0}/{1}", _.Sold, _.Total)
						});
	}
	
	class Guitar {
		public string Brand { get; set; }
		public Status Status { get; set; }
	}
	
	enum Status {
		Sold,
		InStock
	}
