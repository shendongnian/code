    foreach(var item in ItemList)
    {
        AnotherFunction(item.ItemId, item.ItemDate, ItemList.Where(x => x.ItemDate == item.ItemDate)
                                                            .OrderByDesc(z => Convert.ToInt32(z.ItemPrice.Replace("$", "")))
                                                                                     .First().ItemPrice);
    }
