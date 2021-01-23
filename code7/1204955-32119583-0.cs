            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 certificate in store.Certificates)
            {
                if (certificate.SubjectName.Name != null && certs.SubjectName.Name.Contains("*.domain.xxx"))
                {
                    cert = certificate;
                }
            }
    
