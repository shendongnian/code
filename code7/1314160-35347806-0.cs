    public static double DetermineNetworkSortOrderValue(int network, double fee)
    {
        double dictionaryFee;
        return profileNetworkLowCostPriorityList == null ||
            !profileNetworkLowCostPriorityList.TryGetValue(network, out dictionaryFee)
            ? fee : dictionaryFee;
    }
