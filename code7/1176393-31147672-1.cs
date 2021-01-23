    var sponsorRedemptions = db.PurchasedCardDealRedemptions
        .Where(pcdr => pcdr.PurchasedCardDeal.PurchasedCard.Card.WhiteLabelId == whiteLabelId)
        .Where(pcdr => pcdr.RedemptionDate.Year == year)
        .Where(pcdr => pcdr.RedemptionDate.Month == month)
        .Select(pcdr => pcdr.PurchasedCardDeal.Deal);
        .OrderBy(deal => deal.Vendor.Name)
        .GroupBy(deal => deal.Name);
    foreach (var group in sponsorRedemptions)
    {
        Console.WriteLine("Group: {0}", group.Key);
        foreach (var deal in group)
        {
            Console.WriteLine("  {0}", deal.Vendor.Name);
        }
    }
