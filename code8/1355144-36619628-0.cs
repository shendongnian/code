    ServerManager serverManager = new ServerManager();
    
    // get the site (e.g. default)
    Site site = serverManager.Sites.FirstOrDefault(s => s.Name == "Default Web Site");
    // get the application that you are interested in
    Application myApp = site.Applications["/Dev1"];
    
    // get the physical path of the virtual directory
    Console.WriteLine(myApp.VirtualDirectories[0].PhysicalPath);
