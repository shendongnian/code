    foreach (var line in invoice.Lines)
    {
        if (line != null && line.Item != null)
        {
            line.ItemId = line.Item.Id;
            db.Entry(line.Item).State = System.Data.Entity.EntityState.Detached;
        }
    }
