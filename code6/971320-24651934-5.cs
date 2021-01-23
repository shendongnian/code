    var client = new [clientType]();
    client.ClientCredentials.ClientCertificate.Certificate = [certificate];
    client.ClientCredentials.UserName.UserName = [UserName];
    client.ClientCredentials.UserName.Password = [Password];
                         
    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
    // TODO wrap in try catch
    client.Open();
    var result = client.[action](new [RequestType] { ... });
 
