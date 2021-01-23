    using Sodium;
    // snip
    var keypair = PublicKeyBox.GenerateKeyPair();
    string secretKey = Convert.ToBase64String(keypair.PrivateKey);
    string publicKey = Convert.ToBase64String(keypair.PublicKey);
