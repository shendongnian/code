        SelectQuery query = new System.Management.SelectQuery(
            "select name, pathname from Win32_Service");
        using (ManagementObjectSearcher searcher =
            new System.Management.ManagementObjectSearcher(query))
        {
            foreach (ManagementObject service in searcher.Get())
            {
                Console.WriteLine(string.Format(
                    "Name: {0}\tPath : {1}", service["Name"], service["pathname"]));
            }
        }
