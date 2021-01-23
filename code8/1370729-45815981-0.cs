    public static void GetRegistryExclusions()
        {
            ManagementScope scope = new ManagementScope(@"root\standardcimv2\embedded");
            using (ManagementClass mc = new ManagementClass(scope.Path.Path, "UWF_RegistryFilter",
            null))
            {
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    ManagementBaseObject[] result = (ManagementBaseObject[])mo.InvokeMethod("GetExclusions", null, null).Properties["ExcludedKeys"].Value;
                    if (result != null)
                    {
                        foreach (var r in result)
                        {
                            Console.WriteLine(r.GetPropertyValue("RegistryKey"));
                        }
                    }
                }
            }
        }
