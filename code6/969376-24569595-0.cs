    private static List<string> ReadRemoteRegistryusingWMI(string machineName)
            {
            List<string> programs = new List<string>();
            ConnectionOptions connectionOptions = new ConnectionOptions();
            connectionOptions.Username = @"*******";
            connectionOptions.Password = "*******";
            //connectionOptions.Impersonation = ImpersonationLevel.Impersonate;
            ManagementScope scope = new ManagementScope("\\\\" + machineName + "\\root\\CIMV2", connectionOptions);
            scope.Connect();
            string softwareRegLoc = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
            ManagementClass registry = new ManagementClass(scope, new ManagementPath("StdRegProv"), null);
            ManagementBaseObject inParams = registry.GetMethodParameters("EnumKey");
            inParams["hDefKey"] = 0x80000002;//HKEY_LOCAL_MACHINE
            inParams["sSubKeyName"] = softwareRegLoc;
            // Read Registry Key Names 
            ManagementBaseObject outParams = registry.InvokeMethod("EnumKey", inParams, null);
            string[] programGuids = outParams["sNames"] as string[];
            foreach (string subKeyName in programGuids)
                {
                inParams = registry.GetMethodParameters("GetStringValue");
                inParams["hDefKey"] = 0x80000002;//HKEY_LOCAL_MACHINE
                inParams["sSubKeyName"] = softwareRegLoc + @"\" + subKeyName;
                inParams["sValueName"] = "DisplayName";
                // Read Registry Value 
                outParams = registry.InvokeMethod("GetStringValue", inParams, null);
                if (outParams.Properties["sValue"].Value != null)
                    {
                    string softwareName = outParams.Properties["sValue"].Value.ToString();
                    programs.Add(softwareName);
                    }
                }
            return programs;
            }
