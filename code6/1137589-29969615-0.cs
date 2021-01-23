    private bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
        {
            return true;
        }
        // Here you decide whether self-signed certificates are OK
        if (allowAnyCertificate)
        {
            return true;
        }
        return false;
    }
