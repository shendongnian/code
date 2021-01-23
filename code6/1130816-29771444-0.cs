    class LanguagePack 
	{
		public int Category { get; set; }
		public string Description { get; set; }
		public decimal UnitPrice { get; set; }
		public int CurrentQuantity { get; set; }
		public int LanguageName { get; set; }
		
	}
    return (from myStock in allStock
        select new LanguagePack
        {
            Category = myStock.Category,
            Description = myStock.Description,
            UnitPrice = myLowStock.UnitPrice,
            CurrentQuantity = myLowStock.CurrentQuantity,
			LanguageName = "Polish" // or english or whatever... maybe LanguageId or something corresponding to your model
        });
		
	
