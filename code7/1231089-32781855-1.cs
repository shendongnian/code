    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.X509;
    // Your loaded certificate
    X509Certificate cert = null;             
    // Your loaded RSA key   
    AsymmetricKeyParameter privateKey = null;
    AsymmetricKeyParameter publicKey = cert.GetPublicKey();
    ISigner signer = SignerUtilities.GetSigner(cert.SigAlgName);
    // Init for signing, you pass in the private key
    signer.Init(true, privateKey);
    // Init for verification, you pass in the public key
    signer.Init(false, publicKey);
