    [NotMapped]
    public ICollection<int> ProductIds {
       get {
          return Products.Select(p => p.ProductId)
                         .ToList()
    }
