    [NotMapped]
    public int[] ProductIds {
        get {
           return Products.Select(p => p.ProductId)
                          .ToArray()
    
        }
