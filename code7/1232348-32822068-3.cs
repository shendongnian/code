    public ICollection<ProductOption> ProductOptions { get; set; }
    ProductOptions = p.ProductOptions
                      .Where(po => po.Active && !po.Deleted)
                      .Select(po =>
                      new ProductOptionDTO
                      {
                          Id = po.Id,
                          Name = po.Name,
                          Price = po.Price
                      }).ToList()
