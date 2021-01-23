    using System.Security.Cryptography.X509Certificates;
    public static Org.BouncyCastle.X509.X509Certificate Convert(X509Certificate2 certificate) 
    {
        var certificateParser = new Org.BouncyCastle.X509.X509CertificateParser();
        var rawData = certificate.GetRawCertData();
        var bouncyCertificate = certificateParser.ReadCertificate(rawData);
        return bouncyCertificate;
    }
