    var stocksQuery = storeDetails.GroupBy(row => new { row.Store, row.Product }).AsQueryable();
    
            List<StockStatusViewModel> result = new List<StockStatusViewModel>();
            foreach (var item in stocksQuery)
            {
                result.Add(new StockStatusViewModel
                {
                    Quantity = item.Sum(row => row.Quantity),
                    ProductCombinationId = item.Key.ProductAttributeCombinationId,
                    StoreId = item.Key.StoreId,
                    StoreName = item.Key.Store.StoreName,
                    ProductName = item.Key.Product.ProductName
                });
    
            }
