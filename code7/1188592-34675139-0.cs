            public static KeyValuePair<string, string> GetOSVersionAndCaption()
            {
                  KeyValuePair<string, string> kvpOSSpecs = new KeyValuePair<string, string>();
                  ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption, Version FROM Win32_OperatingSystem");
            try
            {
                foreach (var os in searcher.Get())
                {
                    var version = os["Version"].ToString();
                    var productName = os["Caption"].ToString();
                    kvpOSSpecs = new KeyValuePair<string, string>(productName, version);
                }
            }
            catch { }
                
            return kvpOSSpecs;
        }
