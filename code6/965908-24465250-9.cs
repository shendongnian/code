    Collection<Stock> stocks = new Collection<Stock>();
    Collection<Stock> stocks.Add(new Stock 
    {
        StorageId = 123,
        Amount = 1000F
    }); 
    Item item = new Item
    {
        Name = "Pizza",
        Stocks = stocks
    }; 
    this.DbSource.SaveChanges();
