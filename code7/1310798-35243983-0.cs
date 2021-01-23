    public IEnumerable<string> getFilterItems(string dbColumn)
        {
            var filterItems = new List<string>();
    
            var productList = from reading in Helper.LatestReadings
                    where reading.Distributor != Helper.Client
                    join product in Helper.Context.Products
                           on reading.ProductId equals product.SkuCode
                    select product;
             return productList.Select(x=>x.GetType().GetProperty(dbColumn).GetValue(x)).Cast<string>().Distinct();
    }
