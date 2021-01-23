    var loginPBK = "";//your public key,such as "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCp0wHYbg......."
    var provider = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.RsaPkcs1);
    var publicKey = provider.ImportPublicKey(CryptographicBuffer.DecodeFromBase64String(loginPBK));
    var encryptData = CryptographicEngine.Encrypt(publicKey, CryptographicBuffer.ConvertStringToBinary(password, BinaryStringEncoding.Utf8), null);
    var pwd2 = CryptographicBuffer.EncodeToBase64String(encryptData);
