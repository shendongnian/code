    string cPin = "12345";
    System.Security.SecureString SecurePIN = new System.Security.SecureString();
    foreach (char ch in cPin)
    { SecurePIN.AppendChar(ch); }
    var rsa = (RSACryptoServiceProvider)certSigned.PrivateKey;
    string ContinerName = rsa.CspKeyContainerInfo.KeyContainerName;
    string CspName = rsa.CspKeyContainerInfo.ProviderName;
    int CspType = rsa.CspKeyContainerInfo.ProviderType;
    CspParameters csp = new CspParameters(CspType, CspName, ContinerName, new System.Security.AccessControl.CryptoKeySecurity(), SecurePIN);
    RSACryptoServiceProvider CSP = new RSACryptoServiceProvider(csp);
