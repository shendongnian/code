    static void Main(string[] args)
    {
        String serverName = "Print-Server"; //set servername (your own computername if you truly are hosting the printers locally)
        String ipToSearchFor = "10.91.40.75";//ip to search for in this example
        //this loads all TCPPrinterPorts into a Dictionary indexed by the ports Hostaddress (IP)
        //I'm loading all because I assume you are going to iterate over them at some point, since It seems you have a list
        Dictionary<string, ManagementObject> printerPorts = LoadScope(serverName, "select * from Win32_TCPIPPrinterPort");
        //after we've got the ports, open the printserver
        using (PrintServer ps = new PrintServer("\\\\" + serverName))
        {
            //find the queue where queueport.name equals name of port we look up from IP
            var queue = ps.GetPrintQueues().Where(p => p.QueuePort.Name == printerPorts[ipToSearchFor]["Name"].ToString()).FirstOrDefault();
            //print sharename
            Console.WriteLine(queue.ShareName);
        }
    }
    //Loads everything in scope into a dictionary, in this case indexed by hostaddress
    private static Dictionary<string, ManagementObject> LoadScope(string server, string query)
    {
        ManagementScope scope = new ManagementScope("\\\\" + server + "\\root\\cimv2");
        scope.Connect();
        SelectQuery q = new SelectQuery(query);
        ManagementObjectSearcher search = new ManagementObjectSearcher(scope, q);
        ManagementObjectCollection pp = search.Get();
        Dictionary<string, ManagementObject> objects = new Dictionary<string, ManagementObject>();
        foreach (ManagementObject p in pp)
        {
            string name = p["HostAddress"].ToString().ToLower();
            if (!objects.ContainsKey(name))
                objects.Add(name, p);
        }
        return objects;
    }
