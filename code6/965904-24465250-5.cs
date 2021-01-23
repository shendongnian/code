	Item item = this.DbSource.Items.First(itemEntity => itemEntity.Id == 5);
	
	if(item.Stocks == null) item.Stocks = new Collection<Stock>();
	
	item.Stocks.Add(new Stock
	{
		StorageId = 3,
		Amount = 123F
	});
	this.DbSource.SaveChanges();
