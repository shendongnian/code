    double? myPrice = budget / count;
    double roundMyPrice;
    if (myPrice.HasValue)
    {
        roundMyPrice = Math.Round(myPrice.Value, MidpointRounding.AwayFromZero);
    }
    else
    {
        // value is not presented
    }
