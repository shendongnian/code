    bool ValidateRemoteCertificate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
    	Console.WriteLine ("SslPolicyErrors: {0}", sslPolicyErrors);
    
    	return sslPolicyErrors == SslPolicyErrors.None;
    }
