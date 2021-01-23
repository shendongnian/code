            IEnumerable<Certificate> certificates;
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            try
            {
                certificates = from X509Certificate2 certificate in store.Certificates
                               where certificate.HasPrivateKey
                                   //&& certificate.NotAfter <= DateTime.Now && certificate.NotBefore >= DateTime.Now
                               //Commented because doesn't work, strangely
                               && certificate.Extensions.OfType<X509KeyUsageExtension>().Any(ku => ku.KeyUsages == X509KeyUsageFlags.NonRepudiation)
                               select new Certificate
                               {
                                   CommonName = certificate.SubjectName.Decode(X500DistinguishedNameFlags.UseUTF8Encoding),
                                   Id = Encoding.UTF8.GetString(certificate.GetSerialNumber())
                               };
            }
            finally
            {
                store.Close();
            }
