    //..
    SelectQuery query = new SelectQuery("select * from Win32_Process"); //query processes
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
    {
        using (ManagementObjectCollection collection = searcher.Get())
        {
            foreach (var process in collection) //loop through results
            {
                var name = process["name"]; //process name
                //Do something with process
            }
        }
    }
