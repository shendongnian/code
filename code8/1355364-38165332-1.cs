    [DllImport(Libraries.Crypt32, CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern unsafe bool CertSetCertificateContextProperty(IntPtr pCertContext, CertContextPropId dwPropId, CertSetPropertyFlags dwFlags, SafeNCryptKeyHandle pvData);
    internal enum CertContextPropId : int
    {
        CERT_NCRYPT_KEY_HANDLE_PROP_ID = 78,
    }
    [Flags]
    internal enum CertSetPropertyFlags : int
    {
        None = 0,
    }
    private static X509Certificate2 MateECDsaPrivateKey(
        X509Certificate2 cert,
        CngKey privateKey)
    {
        // Make a new certificate instance which isn't tied to the current one
        using (var tmpCert = new X509Certificate2(cert.RawData))
        {
            SafeNCryptKeyHandle keyHandle = privateKey.Handle;
            // Set the ephemeral key handle property
            if (!CertSetCertificateContextProperty(
                tmpCert.Handle,
                CertContextPropId.CERT_NCRYPT_KEY_HANDLE_PROP_ID,
                CertSetPropertyFlags.None,
                keyHandle))
            {
                throw new CryptographicException(Marshal.GetLastWin32Error());
            }
            // You could emit this, if you prefer.
            byte[] pfxBytes = tmpCert.Export(X509ContentType.Pkcs12);
            // Clear the key handle out again to prevent double-free
            keyHandle = new SafeNCryptKeyHandle();
            if (!CertSetCertificateContextProperty(
                tmpCert.Handle,
                CertContextPropId.CERT_NCRYPT_KEY_HANDLE_PROP_ID,
                CertSetPropertyFlags.None,
                keyHandle))
            {
                throw new CryptographicException(Marshal.GetLastWin32Error());
            }
            // Now load a new certificate which has a temporary keyfile on disk.
            // Note: If you don't want exportability here, don't request it.
            var matedCert = new X509Certificate2(pfxBytes, (string)null, X509KeyStorageFlags.Exportable);
            using (ECDsa ecdsa = matedCert.GetECDsaPrivateKey())
            {
                if (ecdsa == null)
                {
                    throw new InvalidOperationException("It didn't work");
                }
            }
            return matedCert;
        }
    }
