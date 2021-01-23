    public holdings FindHoldings(portfolio portfolio, string instrumentId) 
    {
        return FindHoldingsRecursive(portfolio.assetTypes, instrumentId);
    }
    public holdings FindHoldingsRecursive(
        IEnumerable<subAssetType> assetTypes,
        string instrumentId)
    {
        if (assetTypes == null)
            return null;
        return assetTypes
          .Select(a => FindHoldingsRecursive(a, instrumentId))
          .FirstOrDefault(h => h != null);
    }
    public holdings FindHoldingsRecursive(
        subAssetType assetType, 
        string instrumentId)
    {
        return 
            assetType.holdings.FirstOrDefault(h => h.instrumentIdentifier == instrumentId);
            ?? FindHoldingsRecursive(assetType.assetTypes, instrumentId);
    }
