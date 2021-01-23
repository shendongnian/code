    var connectionCost = NetworkInformation.GetInternetConnectionProfile().GetConnectionCost();
    if (connectionCost.NetworkCostType == NetworkCostType.Unknown 
            || connectionCost.NetworkCostType == NetworkCostType.Unrestricted)
    {
        //Connection cost is unknown/unrestricted
    }
    else
    {
       //Metered Network
    }
