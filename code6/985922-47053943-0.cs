    public static string GetVersionOfInstalledApplication(string queryName)
    {
        string name;
        string version;
        Type type = Type.GetTypeFromProgID("WindowsInstaller.Installer");
        Installer installer = Activator.CreateInstance(type) as Installer;
        StringList products = installer.Products;
        foreach (string productGuid in products)
        {
            string currName = installer.ProductInfo[productGuid, "ProductName"];
            string currVersion = installer.ProductInfo[productGuid, "VersionString"];
            if (currName == queryName)
            {
                name = currName;
                version = currVersion;
                return version;
            }
        }
        return null;
    }
