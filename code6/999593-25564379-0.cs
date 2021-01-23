     ServicePointManager.ServerCertificateValidationCallback +=
            EasyCertCheck;
     bool EasyCertCheck(object sender, X509Certificate cert,
       X509Chain chain, System.Net.Security.SslPolicyErrors error)
        {
            return true;
        }
