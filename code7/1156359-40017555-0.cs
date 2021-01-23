    public static void CreateSiteHttps(string siteName, string physicalPath)
    {
        using (var serverManager = new ServerManager())
        {
            var applicationPool = serverManager.ApplicationPools.Add(siteName);
            applicationPool["startMode"] = "AlwaysRunning";
            var x509Store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            x509Store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadWrite);
            var certificate = x509Store.Certificates.Find(X509FindType.FindBySubjectName, "MyCertSubjectName", false)[0];
            var hash = certificate.GetCertHash();
            var site = serverManager.Sites.Add(siteName, $"*:443:{siteName}", physicalPath, hash);
            site.ServerAutoStart = true;
            site.Bindings[0]["sslFlags"] = 1;
            site.ApplicationDefaults.ApplicationPoolName = applicationPool.Name;
            site.ApplicationDefaults.EnabledProtocols = "http,https";
            serverManager.CommitChanges();
        }
    }
