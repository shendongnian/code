    foreach(var nic in NetworkInterface.GetAllNetworkInterfaces())
    {
       if(nic.OperationalStatus == OperationalStatus.Up)
       {
        return nic.GetPhysicalAddress();
       }
    }
    return string.Empty();
