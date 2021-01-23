    var product = db.Products.Where(p => p.ProductId = productId)
                             .Select(pr=> new ProductDTO
                             {
                               ProductId = pr.ProductId,
                               TransactionDates = pr.Transactions.Select(tr=>tr.Date),
                             }.ToList();
     
