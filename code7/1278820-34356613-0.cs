    string ComputerName = "10.1.2.3";
    ManagementScope Scope;
    if (!ComputerName.Equals("localhost", StringComparison.OrdinalIgnoreCase))
    {
        ConnectionOptions Conn = new ConnectionOptions();
        Conn.Username = "Administrator";
        Conn.Password = "pass123";
        //Conn.Authority = "ntlmdomain:DOMAIN";
        Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), Conn);
    }
    else
        Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);
    Scope.Connect(); // CRASH HERE
    ObjectQuery Query = new ObjectQuery("SELECT * FROM Win32_Process Where Name='" + "cmd.exe" + "'");
    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
    ManagementObjectCollection queryCollection = Searcher.Get();
    foreach (var item in queryCollection)
        Console.WriteLine(item["Description"]);
    Console.Read();
