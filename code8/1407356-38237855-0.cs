    public bool SetNetworkConfiguration(string adaptName, string cIPAddress, string cSubnetMask, string cGateway, string[] cDNS, NetworkType nType)
    {
      var mClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
      var nCol = mClass.GetInstances();
    
      foreach (ManagementObject mObject in nCol)
      {
        foreach (var property in mObject.Properties)
        {
          if (property.Name == "Description")
          {
            var searchAdapt = property.Value.ToString();
            if (string.Compare(adaptName, searchAdapt, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
              try
              {
                if (nType == NetworkType.Static)
                {
                  //게이트웨이 셋
                  var newConfig_Gateway = mObject.GetMethodParameters("SetGateways");
                  ManagementBaseObject setConfig_Gateway;
                  newConfig_Gateway["DefaultIPGateway"] = new[] {cGateway};
                  newConfig_Gateway["GatewayCostMetric"] = new[] {1};
    
                  setConfig_Gateway = mObject.InvokeMethod("SetGateways", newConfig_Gateway, null);
    
                  //아이피, 서브마스크 셋
                  var newConfig_IPAddress = mObject.GetMethodParameters("EnableStatic");
                  ManagementBaseObject setConfig_IPAddress;
                  newConfig_IPAddress["IPAddress"] = new[] {cIPAddress};
                  newConfig_IPAddress["SubnetMask"] = new[] {cSubnetMask};
    
                  setConfig_IPAddress = mObject.InvokeMethod("EnableStatic", newConfig_IPAddress, null);
    
                  //DNS셋
                  var newConfig_DNS = mObject.GetMethodParameters("SetDNSServerSearchOrder");
                  ManagementBaseObject setConfig_DNS;
                  newConfig_DNS["DNSServerSearchOrder"] = cDNS;
                  setConfig_DNS = mObject.InvokeMethod("SetDNSServerSearchOrder", newConfig_DNS, null);
                }
                else if (nType == NetworkType.Dynamic)
                {
                  mObject.InvokeMethod("EnableDHCP", null);
                }
                else
                {
                  return false;
                }
    
                return true;
              }
              catch
              {
                return false;
              }
            }
          }
        }
      }
    
      return false;
    }
