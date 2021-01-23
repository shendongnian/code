    static void Main(string[] args)
    {
        string expectedSubjectName = "My Application";
        string expectedIssuerName = "CN=My Company, O=My Company, OU=Created by http://www.mycompany.com";
        string expectedIssuerCN = "My Company"; // x where CN=x above
        string expectedPublicKey = "30818902818100b9f8df149d05f84d29ad7e134de5300c690708a1c225512b35ca5241719e1c37a96aa6c4d6d1154b74ec70010e614e44b2c877015e99407ac1c5b79c15a8faa18fae105aff53616bf4d6cea2505d4eb2a6a566fb4fdeaa43b57a402d3ad77b64c0370a731a91a0d76df824cb1760092f02ed424f4b552a14d12c7c9984b8a2e30203010001"; // public key of your original issuing certificate
        bool isValidApplicationCertificate = CheckForApplicationCertificate(expectedSubjectName, expectedIssuerName, expectedIssuerCN, expectedPublicKey);
    }
    private static void ThrowCertificateNotFoundException(string expectedSubjectName, string expectedIssuerName, bool isIssuerPublicKeyMismatch)
    {
        if (isIssuerPublicKeyMismatch)
        {
            // Notification for possible certificate forgery
        }
        throw new SecurityException("A personal certificate with subject name " + expectedSubjectName + " issued by " + expectedIssuerName + " is required to run this application");
    }
    private static bool CheckForApplicationCertificate(string expectedSubjectName, string expectedIssuerName, string expectedIssuerCN, string expectedIssuerPublicKey)
    {
        X509Store personalCertificateStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        personalCertificateStore.Open(OpenFlags.ReadOnly);
            
        X509CertificateCollection certificatesBySubjectName = personalCertificateStore.Certificates.Find(X509FindType.FindBySubjectName, expectedSubjectName, true);
        if (certificatesBySubjectName.Count == 0)
        {
            ThrowCertificateNotFoundException(expectedSubjectName, expectedIssuerName, false);
        }
        X509Certificate matchingCertificate = null;
        foreach (X509Certificate certificateBySubjectName in certificatesBySubjectName)
        {
            if (certificateBySubjectName.Issuer == expectedIssuerName)
            {
                matchingCertificate = certificateBySubjectName;
                break;
            }
        }
        if (matchingCertificate == null)
        {
            ThrowCertificateNotFoundException(expectedSubjectName, expectedIssuerName, false);
        }
        X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
        X509CertificateCollection issuerCertificatesBySubjectName = personalCertificateStore.Certificates.Find(X509FindType.FindBySubjectName, expectedIssuerCN, true);
        if (issuerCertificatesBySubjectName.Count == 0)
        {
            ThrowCertificateNotFoundException(expectedSubjectName, expectedIssuerName, false);
        }
        if (issuerCertificatesBySubjectName[0].GetPublicKeyString().ToLowerInvariant() != expectedIssuerPublicKey.ToLowerInvariant())
        {
            ThrowCertificateNotFoundException(expectedSubjectName, expectedIssuerName, true);
        }
        return true;
    }
