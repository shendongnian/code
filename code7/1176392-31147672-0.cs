    foreach (var group in sponsorRedemptions)
    {
        Console.WriteLine("Group: {0}", group.Key);
        foreach (var item in group)
        {
            Console.WriteLine("  {0}", item.PurchasedCardDeal.Deal.Vendor.Name);
        }
    }
