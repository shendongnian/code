    using System.Security.Cryptography.X509Certificates;
    using System.Net.Security;
    
    .....
    .....
    //before you make the request
    System.Net.ServicePointManager.ServerCertificateValidationCallback +=
    delegate (
        object sender,
        X509Certificate certificate,
        X509Chain chain,
        SslPolicyErrors sslPolicyErrors)
    {
        Console.WriteLine("Subject: " + certificate.Subject + ", Issuer: " + certificate.Issuer + ". SSL Errors: " + sslPolicyErrors.ToString());
        return false;
    };
