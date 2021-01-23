    X509Store store = new X509Store("My", StoreLocation.CurrentUser);
    store.Open(OpenFlags.ReadOnly);
                              
    X509Certificate2Collection col = (X509Certificate2Collection)store.Certificates.Find(X509FindType.FindBySubjectName, certName, true);
    X509Certificate2 cert = null;
    try
    {
        if(col.Count>0)
        cert = col[0];
    }
    catch (Exception ex)
    {
        throw new Exception("Certificate not Found!");
    }
    store.Close();
