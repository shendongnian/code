        public static ManagementObject GetNetworkAdapterManagementObject(NetworkInterface NetInterface)
        {
            ManagementObject oMngObj = null;
            // Precondition
            if (NetInterface == null) return null;
            string sNI = NetInterface.Id;
            ManagementClass oMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection oMOC = oMC.GetInstances();
            foreach (ManagementObject oMO in oMOC)
            {
                string sMO = oMO["SettingID"].ToString();
                if (sMO == sNI)
                {
                    // Found
                    oMngObj = oMO;
                    break;
                }
            }
            return oMngObj;
        }
