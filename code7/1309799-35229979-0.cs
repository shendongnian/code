        public static void ConnectInterfaceToSwitch(string VmName, string networkInterfaceName, string switchName)
        {
            ManagementScope scope = new ManagementScope(@"root\virtualization\v2");
            ManagementObject mgtSvc = WmiUtilities.GetVirtualMachineManagementService(scope);
            ManagementObject ethernetSwitch = NetworkingUtilities.FindEthernetSwitch(switchName, scope);
            ManagementObject virtualMachine = WmiUtilities.GetVirtualMachine(VmName, scope);
            ManagementObject virtualMachineSettings = WmiUtilities.GetVirtualMachineSettings(virtualMachine);
            ManagementObjectCollection portsSettings = virtualMachineSettings.GetRelated("Msvm_SyntheticEthernetPortSettingData", "Msvm_VirtualSystemSettingDataComponent", null, null, null, null, false, null);
            {                
                foreach (ManagementObject portSettings in portsSettings)
                {
                    if (portSettings["ElementName"].Equals(networkInterfaceName))
                    {
                        Console.WriteLine("Adapter found: " + networkInterfaceName);
                        ManagementObjectCollection connections = portSettings.GetRelated("Msvm_EthernetPortAllocationSettingData");
                        foreach (ManagementObject connection in connections)
                        {
                            connection["HostResource"] = new string[] { ethernetSwitch.Path.Path };
                            connection["EnabledState"] = 2; // 2 means "Enabled"    
                            ManagementBaseObject inParams = mgtSvc.GetMethodParameters("ModifyResourceSettings");
                            inParams["ResourceSettings"] = new string[] { connection.GetText(TextFormat.WmiDtd20) };
                            ManagementBaseObject outParams = mgtSvc.InvokeMethod("ModifyResourceSettings", inParams, null);
                            WmiUtilities.ValidateOutput(outParams, scope);
                            Console.WriteLine(string.Format(CultureInfo.CurrentCulture, "Connected VM '{0}' to switch '{1}'.", VmName, switchName));
                        }
                    }
                }
            }
        }
