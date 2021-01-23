    private  bool IsAcceptedCertificate(X509Certificate2 cert)
    {
        try
        {
            if(cert.Verify() && cert.Issuer.StartsWith("CN=Microsoft"))
                    
            {
                return true;
            }
        }
        catch (CryptographicException ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
    
        //if not microsoft
        return false;
    }
