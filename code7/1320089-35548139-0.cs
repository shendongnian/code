    private string FindByDisplayName(RegistryKey parentKey, string name)
             {
                 string[] nameList = parentKey.GetSubKeyNames();
                 for (int i = 0; i < nameList.Length; i++)
                 {
                     RegistryKey regKey =  parentKey.OpenSubKey(nameList[i]);
                     try
                     {
                         if (regKey.GetValue("DisplayName").ToString() == name)
                         {
                             return regKey.GetValue("InstallLocation").ToString();
                         }
                     }
                     catch { }
                 }
                 return "";
             }
