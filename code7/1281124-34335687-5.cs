        public static bool SetIPAdress(ManagementObject oMO, string[] saIPAdress, string[] saSubnetMask)
        {
            bool bErg = false;
            try
            {
                // Precondition
                if (oMO == null) return false;
                if (saIPAdress == null) return false;
                if (saSubnetMask == null) return false;
                // Get ManagementBaseObject 
                ManagementBaseObject oNewIP = null;
                oNewIP = oMO.GetMethodParameters("EnableStatic");
                oNewIP["IPAddress"] = saIPAdress;
                oNewIP["SubnetMask"] = saSubnetMask;
                // Invoke
                oMO.InvokeMethod("EnableStatic", oNewIP, null);
                // Alles ok
                bErg = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetIPAdress failed: " + ex.Message);
            }
            return bErg;
        }
    }
