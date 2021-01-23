        {
            try
            {
                ManagementObjectSearcher searcher = new
                    ManagementObjectSearcher("\\\\" + machineName + "\\root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject wmi in searcher.Get())
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString();
                }
            }
            catch (COMException ce)
            {
                if ((uint)ce.ErrorCode == 0x800706BA)
                {
                    return "Serial Number : Null";
                }
            }
            return "Serial Number : Null";
        }
