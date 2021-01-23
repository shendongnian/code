     // Use new class
     IQueryable<SellingItem> sellingitems = db.SellingItems
    .GroupBy(s => new { s.ItemId ,s.Condition,s.ExpInDays})
    .Select(si => new NewClass
    {
        Item = si.First().Item,
        Condition = si.First().Condition,
        ExpInDays = si.First().ExpInDays,
        Qty = si.Sum(i => i.Qty),
    });
