      using System;
      using System.Management; 
    namespace WMI3
    {
    class Class1
    {
    static void Main(string[] args)
    {
    Console.WriteLine("Computer details retrieved using Windows Management    Instrumentation (WMI)");
    //Connect to the remote computer
    ConnectionOptions co = new ConnectionOptions();
    co.Username = "username";
    co.Password = "Pass";
    string serverName="servername"
    System.Management.ManagementScope ms = new       
    System.Management.ManagementScope(servername + "\\root\\cimv2", co); 
    //Query remote computer across the connection
    System.Management.ObjectQuery oq = new   System.Management.ObjectQuery("SELECT * FROM Win32_OperatingSystem");
    ManagementObjectSearcher query1 = new ManagementObjectSearcher(ms,oq);
    ManagementObjectCollection queryCollection1 = query1.Get(); 
    foreach( ManagementObject mo in queryCollection1 ) 
    {
    string[] ss={""};
    mo.InvokeMethod("Reboot",ss);
    Console.WriteLine(mo.ToString());
    }
    }
    }
    }
