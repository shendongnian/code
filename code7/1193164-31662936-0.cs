    request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { 
        // investigate certificate parameter
        X509Certificate2 x509 = new X509Certificate2(certificate);
        Console.WriteLine("Certificate expired on: {0}", x509.NotAfter);
        return true; // true to bypass, false otherwise
    };
    ...
    request.GetResponse();
