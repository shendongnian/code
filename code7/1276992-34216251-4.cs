    public static class ModemReader // or not static. it's up to you
    {
        public static string[] DetectModems() // I would use string[] because you won't modify it
        {
            List<string> result = new List<string>();
     
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_POTSModem");
            foreach (ManagementObject queryObj in searcher.Get()){
                if ((string)queryObj["Status"] == "OK"){
                   result.Add(queryObj["AttachedTo"] + " - " + System.Convert.ToString(queryObj["Description"]));
                }
            }
            return result.ToArray();
        }
    }
