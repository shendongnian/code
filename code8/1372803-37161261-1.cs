    var stocksQuery = storeDetails.GroupBy(row => new { row.StoreId, row.Store.StoreName, row.ProductId, row.Product.ProductName }).AsQueryable();
        
                List<StockStatusViewModel> result = new List<StockStatusViewModel>();
                foreach (var item in stocksQuery)
                {
                    result.Add(new StockStatusViewModel
                    {
                        Quantity = item.Sum(row => row.Quantity),
                        ProductCombinationId = item.Key.ProductAttributeCombinationId,
                        StoreId = item.Key.StoreId,
                        StoreName = item.Key.StoreName,
                        ProductName = item.Key.ProductName
                    });
        
                }
