    var query = db.ProductGraphicsCards
        .Where(pgc => pgc.GraphicsCardSKU.StartsWith(term))
        .Select(pgc => new
        {
            GraphicsCardSKU = pgc.GraphicsCardSKU,
            GraphicsCardMemory = pgc.GraphicsCardMemory
        };
    var products = await query.ToListAsync();
    // ...
