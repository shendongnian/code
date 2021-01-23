    [HttpPost]
    public async Task<ActionResult> List(DataSourceRequest command, ProductListModel model)
    {
      var categories = _productService.GetAllProducts(model.SearchProductName,
          command.Page - 1, command.PageSize);
      var data = new List<ProductModel>();
      foreach (var x in categories)
      {
        var productModel = x.ToModel();
        var manufacturer = await _manufacturerService.GetManufacturerById(x.ManufacturerId);
        var category = await _categoryService.GetCategoryById(x.CategoryId);
        productModel.Category = category.Name;
        productModel.Manufacturer = manufacturer.Name;
        data.Add(productModel);
      }
      var gridModel = new DataSourceResult
      {
        Data = data,
        Total = categories.TotalCount
      };
      return Json(gridModel);
    }
