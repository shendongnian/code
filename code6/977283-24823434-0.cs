    var location = _webHelper.GetStoreLocation(false);
    foreach (var store in stores)
    {
         var seName = store.GetSeName();
        //TODO add a method for getting URL (use routing because it handles all SEO friendly URLs)
         if (store.Id != 1)
         {
             var products = _productService.SearchProducts(0, 0, null, null, null, 0, null, false, 1, new List<int>(), ProductSortingEnum.Position, 0, int.MaxValue, store.Id, false);
             foreach (var product in products)
             {
                 var url = string.Format("{0}s/{1}/{2}/p/{3}/{4}", location, store.Id, seName, product.Id, seName);
                 var updateFrequency = UpdateFrequency.Weekly;
                 var updateTime = product.UpdatedOnUtc;
                 WriteUrlLocation(url, updateFrequency, updateTime);
             }
         }
    }
