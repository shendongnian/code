     /// <summary>
        /// TEST AND SET GLOBAL KEYBOARD ATTACHED BOOL keyB
        /// </summary>
        internal static void TestKeyboard()
        {
            keyB = false;
            //FIND WHETHER A USB KEYBOARD IS PLUGGED IN
            HidSharp.HidDeviceLoader hd = new HidSharp.HidDeviceLoader();
            foreach (HidSharp.HidDevice item in hd.GetDevices())
            {
                if (item.ProductName.Contains("Keyboard"))
                {
                    keyB = true;
                    return;
                }
            }
            //FIND WHETHER A PS/2 KEYBOARD IS PLUGGED IN.
            string query = "select * from Win32_Keyboard";
            System.Management.ObjectQuery oQuery = new ObjectQuery(query);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(oQuery);
            ManagementObjectCollection recordSet = searcher.Get();
            foreach (ManagementObject record in recordSet)
            {
                if (record.Properties["Description"].Value.ToString().Contains("Keyboard"))
                {
                    keyB = true;
                    return;
                }
            }
            
        }
