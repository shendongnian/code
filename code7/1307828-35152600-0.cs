    var connectionProfile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
    if (connectionProfile.IsWlanConnectionProfile)
    {
         // It's wireless
         // You can load images, videos, etc. (your business here).
    }
    else if (connectionProfile.IsWwanConnectionProfile)
    {  
         // It's mobile.
         // You'll probably want to perform some handling 
         // to inform the user that your items are not loaded 
         // because they're using a metered connection.
    }
