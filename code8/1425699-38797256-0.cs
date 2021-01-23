    var prod = db.Products
                .Where(p => p.Id == 1)
                .Select(p => new
                {
                    p.Id,
                    Categories = p.Categorizations.Select(c => c.Category).ToList()
                })
                .FirstOrDefault();
