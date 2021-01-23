    var collection = new X509Certificate2Collection();
    collection.Import(System.Web.Hosting.HostingEnvironment.MapPath(pathToPrivateKey), privateKeyPassword, X509KeyStorageFlags.MachineKeySet);
    
    var requestToPing = (HttpWebRequest)WebRequest.Create(dropOffURL);
    requestToPing.Method = "POST";
    requestToPing.PreAuthenticate = true;
    requestToPing.ClientCertificates.Add(collection[0]);
