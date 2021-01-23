    public async static Task<string> Sign(Windows.Security.Cryptography.Certificates.Certificate cert, string messageToSign) {
        var messageBytes = Encoding.UTF8.GetBytes(messageToSign);
        using (var ms = new MemoryStream(messageBytes)) {
            var si = new CmsSignerInfo() {
                Certificate = cert,
                HashAlgorithmName = HashAlgorithmNames.Sha256
            };
            var signature = await CmsDetachedSignature.GenerateSignatureAsync(ms.AsInputStream(), new[] { si }, null);
            return CryptographicBuffer.EncodeToBase64String(signature);
        }
    }
