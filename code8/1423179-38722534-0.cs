     public void AddCertificate()
        {
            if (this.ClientCertificates == null)
            {
                this.ClientCertificates = new X509CertificateCollection();
            }
            X509Certificate cert = new X509Certificate(path, pass, X509KeyStorageFlags.MachineKeySet);
            this.ClientCertificates.Add(cert);
        }
