    if (connectionCost.Roaming || connectionCost.OverDataLimit)
    {
        Cost = NetworkCost.OptIn;
        Reason = connectionCost.Roaming
            ? "Connection is roaming; using the connection may result in additional charge."
            : "Connection has exceeded the usage cap limit.";
    }
    else if (connectionCost.NetworkCostType == NetworkCostType.Fixed
        || connectionCost.NetworkCostType == NetworkCostType.Variable)
    {
        Cost = NetworkCost.Conservative;
        Reason = connectionCost.NetworkCostType == NetworkCostType.Fixed
            ? "Connection has limited allowed usage."
            : "Connection is charged based on usage. ";
    }
    else
    {
        Cost = NetworkCost.Normal;
        Reason = connectionCost.NetworkCostType == NetworkCostType.Unknown
            ? "Connection is unknown"
            : "Connection cost is unrestricted";
    }
