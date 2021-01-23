public static string SymmetricDecrypt(this string cipherText, string key, SymmetricAlgorithm algorithm) {
    byte[] keyBuffer = Convert.FromBase64String(key.Hash(HashAlgorithm.MD5));
    byte[] cipherTextBuffer = Convert.FromBase64String(cipherText);
    ISymmetricKeyAlgorithmProvider symmetricAlgorithm = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(PCLCrypto.SymmetricAlgorithm.AesEcbPkcs7);
    var symmetricKey = symmetricAlgorithm.CreateSymmetricKey(keyBuffer);
    var decryptor = WinRTCrypto.CryptographicEngine.CreateDecryptor(symmetricKey);
   byte[] plainTextBuffer = decryptor.TransformFinalBlock(cipherTextBuffer, 0, cipherTextBuffer.Length);
    return UTF8Encoding.UTF8.GetString(plainTextBuffer, 0, plainTextBuffer.Length);
}
