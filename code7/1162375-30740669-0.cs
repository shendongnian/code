    public static class ServiceExtensions
    {
        /// <summary>
        /// Ensures the application certificate is present and valid.
        /// </summary>
        public static void EnsureApplicationCertificate(this ApplicationConfiguration configuration)
        {
            const ushort keySize = 1024;
            const ushort lifetimeInMonths = 300;
    
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }
            bool errorFlag = false;
            string hostName = Dns.GetHostName();
            var serverDomainNames = configuration.GetServerDomainNames();
            var applicationCertificate = configuration.SecurityConfiguration.ApplicationCertificate;
            var certificate = applicationCertificate.Find(true);
            if (certificate != null)
            {
                // if cert found then check domains
                var domainsFromCertficate = Utils.GetDomainsFromCertficate(certificate);
                foreach (string serverDomainName in serverDomainNames)
                {
                    if (Utils.FindStringIgnoreCase(domainsFromCertficate, serverDomainName))
                    {
                        continue;
                    }
                    if (String.Equals(serverDomainName, "localhost", StringComparison.OrdinalIgnoreCase))
                    {
                        if (Utils.FindStringIgnoreCase(domainsFromCertficate, hostName))
                        {
                            continue;
                        }
                        var hostEntry = Dns.GetHostEntry(hostName);
                        if (hostEntry.Aliases.Any(alias => Utils.FindStringIgnoreCase(domainsFromCertficate, alias)))
                        {
                            continue;
                        }
                        if (hostEntry.AddressList.Any(ipAddress => Utils.FindStringIgnoreCase(domainsFromCertficate, ipAddress.ToString())))
                        {
                            continue;
                        }
                    }
                    Trace.TraceInformation("The application is configured to use domain '{0}' which does not appear in the certificate.", serverDomainName);
                    errorFlag = true;
                } // end for
                // if no errors and keySizes match
                if (!errorFlag && (keySize == certificate.PublicKey.Key.KeySize))
                {
                    return; // cert okay
                }
            }
            // if we get here then we'll create a new cert
            if (certificate == null)
            {
                certificate = applicationCertificate.Find(false);
                if (certificate != null)
                {
                    Trace.TraceInformation("Matching certificate with SubjectName '{0}' found but without a private key.", applicationCertificate.SubjectName);
                }
            }
            // lets check if there is any to delete
            if (certificate != null)
            {
                using (var store2 = applicationCertificate.OpenStore())
                {
                    store2.Delete(certificate.Thumbprint);
                }
            }
            if (serverDomainNames.Count == 0)
            {
                serverDomainNames.Add(hostName);
            }
            CertificateFactory.CreateCertificate(applicationCertificate.StoreType, applicationCertificate.StorePath, configuration.ApplicationUri, configuration.ApplicationName, null, serverDomainNames, keySize, lifetimeInMonths);
            Trace.TraceInformation("Created new certificate with SubjectName '{0}', in certificate store '{1}'.", applicationCertificate.SubjectName, applicationCertificate.StorePath);
            configuration.CertificateValidator.Update(configuration.SecurityConfiguration);
        }
    
    }
 
