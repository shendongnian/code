    public static void MassStockInsert(List<Stock> stocks)
        {
            using (var db = new Processor())
            {
                db.BulkCopy(stocks);
            }
            Processor.Stocks = ReloadStocks();
        }
