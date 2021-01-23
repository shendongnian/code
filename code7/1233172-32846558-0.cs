    var temp = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
    if (temp.IsWlanConnectionProfile)
    {
         // its wireless
    }else if (temp.IsWwanConnectionProfile)
    {
         // its mobile
    }
