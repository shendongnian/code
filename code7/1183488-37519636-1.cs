    private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                // For Server Certificate Authentication Errors
                if (sslPolicyErrors == SslPolicyErrors.None)
                    return true;
    
                Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
    
                // Do not allow this client to communicate with unauthenticated servers.
                return false;
    
                // Return True if you want to accept all certificate.
                //return true;
            }
