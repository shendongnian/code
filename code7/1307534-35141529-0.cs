    var existingStock = db.Stocks
                          .Include(s => s.StockDescription) // <= added
                          .Where(s => s.Code == viewModel.Code)
                          .FirstOrDefault<Stock>();
    if(existingStock == null)
    {
        Stock stock = new Stock(viewModel);
        db.Stocks.Add(stock);
    }
    else
    {
        // Line added:
        db.Entry(existingStock.StockDescription).State = EntityState.Deleted;
        existingStock.UpdateStock(viewModel);
        // Not necessary:
        // db.Entry(existingStock).State = EntityState.Modified;
    }
    db.SaveChanges();
