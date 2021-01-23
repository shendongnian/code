    var product = db.Products.Where(p => p.ProductId = productId)
                             .Select(pr=> new 
                             {
                               product = pr,
                               transactionDates = pr.Transactions.Select(tr=>tr.Date),
                             }.ToList();
