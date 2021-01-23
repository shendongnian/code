	Storage storage = this.DbSource.Storages.First(storageEntity => storageEntity.Id == 3);
	
	if(storage.Stocks == null) storage.Stocks = new Collection<Stock>();
	
	Stock stock = new Stock
	{
		StorageId = 3,
		Amount = 123F,
		Item = new Item
		{
			Name = "Redbull"
		}
	};
	
	storage.Stocks.Add(stock);
	this.DbSource.SaveChanges();
