    using Microsoft.SqlServer.Management.Smo;
    
     void DetachDatabase()
     {
          Server smoServer = new Server("MSSQLSERVER2008");
          smoServer.DetachDatabase("Yourdatabasename", False);
     }
