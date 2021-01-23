    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.DirectoryServices.ActiveDirectory;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Security.Cryptography.X509Certificates;
    using CERTENROLLLib;
    /// <summary>
    ///     Converts Domain.local into CN=Domain, CN=local
    /// </summary>
    private static string GetDomainDn()
    {
        var fqdnDomain = IPGlobalProperties.GetIPGlobalProperties().DomainName;
        if (string.IsNullOrWhiteSpace(fqdnDomain)) return null;
        var context = new DirectoryContext(DirectoryContextType.Domain, fqdnDomain);
        var d = Domain.GetDomain(context);
        var de = d.GetDirectoryEntry();
        return de.Properties["DistinguishedName"].Value.ToString();
    }
    /// <summary>
    ///     Gets machine and domain name in X.500-format: CN=PC,DN=MATESO,DN=local
    /// </summary>
    private static string GetMachineDn()
    {
        var machine = "CN=" + Environment.MachineName;
        var dom = GetDomainDn();
        return machine + (string.IsNullOrWhiteSpace(dom) ? "" : ", " + dom);
    }
    /// <summary>
    ///     Creates a self-signed certificate in the computer certificate store MY.
    ///     Issuer and Subject are computername and its domain.
    /// </summary>
    /// <param name="friendlyName">Friendly-name of the certificate</param>
    /// <param name="password">Password which will be used by creation. I think it's obsolete...</param>
    /// <returns>Created certificate</returns>
    /// <remarks>Base from http://stackoverflow.com/a/13806300/5243037 </remarks>
    public static X509Certificate2 CreateSelfSignedCertificate(string friendlyName, string password)
    {
        // create DN for subject and issuer
        var dnHostName = new CX500DistinguishedName();
        // DN will be in format CN=machinename, DC=domain, DC=local for machinename.domain.local
        dnHostName.Encode(GetMachineDn());
        var dnSubjectName = dnHostName;
        //var privateKey = new CX509PrivateKey();
        var typeName = "X509Enrollment.CX509PrivateKey";
        var type = Type.GetTypeFromProgID(typeName);
        if (type == null)
        {
            throw new Exception(typeName + " is not available on your system: 0x80040154 (REGDB_E_CLASSNOTREG)");
        }
        var privateKey = Activator.CreateInstance(type) as IX509PrivateKey;
        if (privateKey == null)
        {
            throw new Exception("Your certlib does not know an implementation of " + typeName +
                                " (in HKLM:\\SOFTWARE\\Classes\\Interface\\)!");
        }
        privateKey.ProviderName = "Microsoft Enhanced RSA and AES Cryptographic Provider";
        privateKey.ProviderType = X509ProviderType.XCN_PROV_RSA_AES;
        // key-bitness
        privateKey.Length = 2048;
        privateKey.KeySpec = X509KeySpec.XCN_AT_KEYEXCHANGE;
        privateKey.MachineContext = true;
        // Don't allow export of private key
        privateKey.ExportPolicy = X509PrivateKeyExportFlags.XCN_NCRYPT_ALLOW_EXPORT_NONE;
        // use is not limited
        privateKey.Create();
        // Use the stronger SHA512 hashing algorithm
        var hashobj = new CObjectId();
        hashobj.InitializeFromAlgorithmName(ObjectIdGroupId.XCN_CRYPT_HASH_ALG_OID_GROUP_ID,
            ObjectIdPublicKeyFlags.XCN_CRYPT_OID_INFO_PUBKEY_ANY,
            AlgorithmFlags.AlgorithmFlagsNone, "SHA512");
        // add extended key usage if you want - look at MSDN for a list of possible OIDs
        var oid = new CObjectId();
        oid.InitializeFromValue("1.3.6.1.5.5.7.3.1"); // SSL server
        var oidlist = new CObjectIds { oid };
        var eku = new CX509ExtensionEnhancedKeyUsage();
        eku.InitializeEncode(oidlist);
        // add all IPs of current machine as dns-names (SAN), so a user connecting to our wcf 
        // service by IP still claim-trusts this server certificate
        var objExtensionAlternativeNames = new CX509ExtensionAlternativeNames();
        {
            var altNames = new CAlternativeNames();
            var dnsHostname = new CAlternativeName();
            dnsHostname.InitializeFromString(AlternativeNameType.XCN_CERT_ALT_NAME_DNS_NAME, Environment.MachineName);
            altNames.Add(dnsHostname);
            foreach (var ipAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if ((ipAddress.AddressFamily == AddressFamily.InterNetwork ||
                     ipAddress.AddressFamily == AddressFamily.InterNetworkV6) && !IPAddress.IsLoopback(ipAddress))
                {
                    var dns = new CAlternativeName();
                    dns.InitializeFromString(AlternativeNameType.XCN_CERT_ALT_NAME_DNS_NAME, ipAddress.ToString());
                    altNames.Add(dns);
                }
            }
            objExtensionAlternativeNames.InitializeEncode(altNames);
        }
        // Create the self signing request
        //var cert = new CX509CertificateRequestCertificate();
        typeName = "X509Enrollment.CX509CertificateRequestCertificate";
        type = Type.GetTypeFromProgID(typeName);
        if (type == null)
        {
            throw new Exception(typeName + " is not available on your system: 0x80040154 (REGDB_E_CLASSNOTREG)");
        }
        var cert = Activator.CreateInstance(type) as IX509CertificateRequestCertificate;
        if (cert == null)
        {
            throw new Exception("Your certlib does not know an implementation of " + typeName +
                                " (in HKLM:\\SOFTWARE\\Classes\\Interface\\)!");
        }
        cert.InitializeFromPrivateKey(X509CertificateEnrollmentContext.ContextMachine, privateKey, "");
        cert.Subject = dnSubjectName;
        cert.Issuer = dnHostName; // the issuer and the subject are the same
        cert.NotBefore = DateTime.Now.AddDays(-1);
        // this cert expires immediately. Change to whatever makes sense for you
        cert.NotAfter = DateTime.Now.AddYears(1);
        cert.X509Extensions.Add((CX509Extension)eku); // add the EKU
        cert.X509Extensions.Add((CX509Extension)objExtensionAlternativeNames);
        cert.HashAlgorithm = hashobj; // Specify the hashing algorithm
        cert.Encode(); // encode the certificate
        // Do the final enrollment process
        //var enroll = new CX509Enrollment();
        typeName = "X509Enrollment.CX509Enrollment";
        type = Type.GetTypeFromProgID(typeName);
        if (type == null)
        {
            throw new Exception(typeName + " is not available on your system: 0x80040154 (REGDB_E_CLASSNOTREG)");
        }
        var enroll = Activator.CreateInstance(type) as IX509Enrollment;
        if (enroll == null)
        {
            throw new Exception("Your certlib does not know an implementation of " + typeName +
                                " (in HKLM:\\SOFTWARE\\Classes\\Interface\\)!");
        }
        // Use private key to initialize the certrequest...
        enroll.InitializeFromRequest(cert);
        enroll.CertificateFriendlyName = friendlyName; // Optional: add a friendly name
        var csr = enroll.CreateRequest(); // Output the request in base64 and install it back as the response
        enroll.InstallResponse(InstallResponseRestrictionFlags.AllowUntrustedCertificate, csr,
            EncodingType.XCN_CRYPT_STRING_BASE64, password);
        // This will fail on Win2k8, some strange "Parameter is empty" error... Thus we search the
        // certificate by serial number with the managed X509Store-class
        // // output a base64 encoded PKCS#12 so we can import it back to the .Net security classes
        //var base64Encoded = enroll.CreatePFX(password, PFXExportOptions.PFXExportChainNoRoot, EncodingType.XCN_CRYPT_STRING_BASE64);
        //return new X509Certificate2(Convert.FromBase64String(base64Encoded), password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);
        var certFs = LoadCertFromStore(cert.SerialNumber);
        if (!certFs.HasPrivateKey) throw new InvalidOperationException("Created certificate has no private key!");
        return certFs;
    }
    private static X509Certificate2 LoadCertFromStore(string serialNumber)
    {
        var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
        store.Open(OpenFlags.OpenExistingOnly | OpenFlags.MaxAllowed);
        try
        {
            // serialnumber from certenroll.dll v6 is a base64 encoded byte array, which is reversed.
            // serialnumber from certenroll.dll v10 is a base64 encoded byte array, which is NOT reversed.
            var serialBytes = Convert.FromBase64String(serialNumber);
            var serial = BitConverter.ToString(serialBytes.ToArray()).Replace("-", "");
            var serialReversed = BitConverter.ToString(serialBytes.Reverse().ToArray()).Replace("-", "");
            var serverCerts = store.Certificates.Find(X509FindType.FindBySerialNumber, serial, false);
            if (serverCerts.Count == 0)
            {
                serverCerts = store.Certificates.Find(X509FindType.FindBySerialNumber, serialReversed, false);
            }
            if (serverCerts.Count == 0)
            {
                throw new KeyNotFoundException("No certificate with serial number <" + serial + "> or reversed serial <" + serialReversed + "> found!");
            }
            if (serverCerts.Count > 1)
            {
                throw new Exception("Found multiple certificates with serial <" + serial + "> or reversed serial <" + serialReversed + ">!");
            }
            return serverCerts[0];
        }
        finally
        {
            store.Close();
        }
    }
