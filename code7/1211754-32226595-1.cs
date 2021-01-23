    IList<IGrouping<string, PurchaseHistory>> results = someList.GroupBy(x => x.UserName);
    foreach (IGrouping<string, PurchaseHistory> group in results)
    {
        foreach (PurchaseHistory item in group)
        {
            CheckforStuff(item);
        }
    }
