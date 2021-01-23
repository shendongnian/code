    IList<IGrouping<string, PurchaseHistory>> results = someList.GroupBy(x => x.UserName);
    foreach (IGrouping<string, PurchaseHistory> group in results)
    {
        bool result = group.Any(item => item.PurchasedOn > someDate);
    }
