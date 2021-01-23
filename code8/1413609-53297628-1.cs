    client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
        new X509ServiceCertificateAuthentication()
        {
            CertificateValidationMode = X509CertificateValidationMode.None,
            RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
        };
