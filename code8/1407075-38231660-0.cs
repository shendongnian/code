        X509Certificate2 authorityCert = GetAuthorityCertificate();
        X509Certificate2 certificateToCheck = GetYourCertificate();
        X509Chain chain = new X509Chain();
        chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
        chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
        chain.ChainPolicy.VerificationTime = DateTime.Now;
        chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);
        //Adding your CA root to the chain
        chain.ChainPolicy.ExtraStore.Add(authorityCert);
        bool isChainValid = chain.Build(certificateToCheck);
        if (!isChainValid)
        {
            //Ok, let c what is wrong...
            string[] errors = chain.ChainStatus
                .Select(m => $"{m.StatusInformation.Trim()}, status: {m.Status}")
                .ToArray();
            string certificateErrors = "Error occured during checking certificate.";
            if (errors != null && errors.Length > 0)
                certificateErrors = string.Join(" \n", errors);
            throw new ApplicationException("Trust chain is not from known authority. Errors: " + certificateErrors);
        }
        //Let see if our chain actually contains known root, for which you are cheking
        if (!chain.ChainElements
            .Cast<X509ChainElement>()
            .Any(m => m.Certificate.Thumbprint == authorityCert.Thumbprint))
            throw new ApplicationException("Could not locate CA root!Thumbprints did not match.");
