    public static int Main(string[] args)
    {
        PackageManager packageManager = new PackageManager();
    
        IEnumerable<Windows.ApplicationModel.Package> packages = 
            (IEnumerable<Windows.ApplicationModel.Package>) packageManager.FindPackages();
    
        int packageCount = 0;
        foreach (var package in packages)
        {
            DisplayPackageInfo(package);
    
            packageCount += 1;
        }
    
        if (packageCount < 1)
        {
            Console.WriteLine("No packages were found.");
        }
    }
    
    private static void DisplayPackageInfo(Windows.ApplicationModel.Package package)
    {
        Console.WriteLine("Name: {0}", package.Id.Name);
    
        Console.WriteLine("FullName: {0}", package.Id.FullName);
    
        Console.WriteLine("Version: {0}.{1}.{2}.{3}", package.Id.Version.Major, package.Id.Version.Minor,
            package.Id.Version.Build, package.Id.Version.Revision);
    
        Console.WriteLine("Publisher: {0}", package.Id.Publisher);
    
        Console.WriteLine("PublisherId: {0}", package.Id.PublisherId);
    
        Console.WriteLine("Installed Location: {0}", package.InstalledLocation.Path);
    
        Console.WriteLine("IsFramework: {0}", package.IsFramework);
    }
