    public List<ProductViewModel> GetPagedFilterProducts(int page, int type_id1, int type_id2)
    {
      int recordsPerPage = 20;
      var skipRecords = page * recordsPerPage;
      var results = _products.GetAll().Where(p => p.type == type_id1 || p.type == type_id2).Select(p => new ProductViewModel
      {
        productId = p.product_id,
        productTitle = p.product_title,
      }).OrderByDescending(p => p.productTitle)
      .Skip(skipRecords)
      .Take(recordsPerPage).ToList();
      return results.Distinct().ToList();
