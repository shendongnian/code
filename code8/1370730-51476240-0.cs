    public static string GetFilterDetail()
    {
      string details = "";
      string detailsCurrent = "";
      string detailsNext = "";
      try
      {
        // Get WMI provider for UWF
        var scope = new ManagementScope(@"\\localhost\root\StandardCimv2\embedded");
        var managementPath = scope.Path.Path;
        using (ManagementClass volumeFilterClass = new ManagementClass(managementPath, "UWF_Volume", null))
        {
          var volumeFilters = volumeFilterClass?.GetInstances();
          if (volumeFilters != null && volumeFilters.Count > 0)
          {
            foreach (ManagementObject volumeFilter in volumeFilters)
            {
              if (volumeFilter != null)
              {
                // Now we have access to the Volume's WMI provider class
                // First check if this is a valid Volume instance, as from trial and error it seems that is not always the case.
                // Some invalid/undocumented instances throw a Not Found ManagementException on the GetExclusions method.
                // Some also throw a NullReferenceException on mo.GetPropertyValue("Protected"), but that covers less cases.
                bool isInstanceValid = true;
                try
                {
                  volumeFilter.InvokeMethod("GetExclusions", null, null);
                }
                catch (ManagementException ex)
                {
                  if (ex.Message.ToLower().Contains("not found"))
                    isInstanceValid = false;
                  else throw ex;
                }
                if (isInstanceValid)
                {
                  bool currentSession = ((bool)volumeFilter.GetPropertyValue("CurrentSession"));
                  string driveLetter = (string)volumeFilter.GetPropertyValue("DriveLetter");
                  bool isProtected = ((bool)volumeFilter.GetPropertyValue("Protected"));
                  string detail = "Volume " + driveLetter + " is " + (isProtected ? "protected" : "not protected") + ".\n";
                  detail += "Excluded files:\n";
                  ManagementBaseObject outParams = volumeFilter.InvokeMethod("GetExclusions", null, null);
                  if (outParams != null)
                  {
                    var excludedItems = (ManagementBaseObject[])outParams["ExcludedFiles"];
                    if (excludedItems != null)
                    {
                      foreach (var excludedItem in excludedItems)
                      {
                        detail += "    " + driveLetter + excludedItem["FileName"] + "\n";
                      }
                    }
                    else detail += "    [No excluded files]\n";
                  }
                  if (currentSession)
                    detailsCurrent += detail;
                  else
                    detailsNext += detail;
                }
              }
            }
          }
        }
        using (ManagementClass registryFilterClass = new ManagementClass(managementPath, "UWF_RegistryFilter", null))
        {
          var registryFilters = registryFilterClass?.GetInstances();
          if (registryFilters != null && registryFilters.Count > 0)
          {
            foreach (ManagementObject registryFilter in registryFilters)
            {
              if (registryFilter != null)
              {
                // Now we have access to the RegistryFilter's WMI provider class
                bool currentSession = ((bool)registryFilter.GetPropertyValue("CurrentSession"));
                string detail = "Excluded registry keys:\n";
                ManagementBaseObject outParams = registryFilter.InvokeMethod("GetExclusions", null, null);
                if (outParams != null)
                {
                  var excludedItems = (ManagementBaseObject[])outParams["ExcludedKeys"];
                  if (excludedItems != null)
                  {
                    foreach (var excludedItem in excludedItems)
                    {
                      detail += "    " + excludedItem["RegistryKey"] + "\n";
                    }
                  }
                  else detail += "    [No excluded registry keys]\n";
                }
                if (currentSession)
                  detailsCurrent += detail;
                else
                  detailsNext += detail;
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        details += ex.ToString();
      }
      details += "\nNOTE: These settings are only active if the Write Filter is Enabled\n"
              + "\nCURRENT SETTINGS:\n" + detailsCurrent
              + "\nNEXT SETTINGS: (after next reboot)\n" + detailsNext;
      return details;
    }
