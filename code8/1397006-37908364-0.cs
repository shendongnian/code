                using (var session = Database.OpenSession())
                {
                    var products = session.CreateCriteria<Product>();
    
                    if (names == null)
                    {
                        return products.List<Product>();
                    }
    
                    var orClause = Expression.Disjunction();
    
                    foreach (var name in names)
                    {
                        orClause.Add(Expression.Like(nameof(Product.Name), name, MatchMode.Start));
                    }
    
                    products.Add(orClause);
    
                    return products.List<Product>();
                }
