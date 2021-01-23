    IQueryable<SellingItem> sellingitems = db.SellingItems
    .GroupBy(s => new { s.ItemId ,s.Condition,s.ExpInDays})
    .Select(si => new
    {
        Item = si.First().Item,
        Condition = si.First().Condition,
        ExpInDays = si.First().ExpInDays,
        Qty = si.Sum(i => i.Qty),
    });
