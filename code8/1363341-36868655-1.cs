    foreach (var itm in bsItems.List)
    {
        if (itm.IsEqual(item))
        {
            bsItems.Position = bsItems.List.IndexOf(itm);
            break;
        }
    }
