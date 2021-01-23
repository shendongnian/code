    public static Expression<Func<Product, bool>> ContainsInDescription (
                                                params string[] keywords)
     
    {
    var predicate = PredicateBuilder.False<Product>();
    foreach (string keyword in keywords)
    {
      string temp = keyword;
      predicate = predicate.Or (p => p.Description.Contains (temp));
    }
    return predicate;
    
    var classics = Product.ContainsInDescription ("Nokia", "Ericsson")
                      .And (Product.IsSelling());
