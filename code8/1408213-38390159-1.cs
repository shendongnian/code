    public static async Task<bool> VerifyCertificateKeyAccess(Certificate selectedCertificate)
    {
        bool VerifyResult = false;  // default to access failure
        CryptographicKey keyPair = await PersistedKeyProvider.OpenKeyPairFromCertificateAsync(
                                            selectedCertificate, HashAlgorithmNames.Sha1, 
                                            CryptographicPadding.RsaPkcs1V15);
        String buffer = "Data to sign";
        IBuffer Data = CryptographicBuffer.ConvertStringToBinary(buffer, BinaryStringEncoding.Utf16BE);
    
        try
        {
            //sign the data by using the key
            IBuffer Signed = await CryptographicEngine.SignAsync(keyPair, Data);
            VerifyResult = CryptographicEngine.VerifySignature(keyPair, Data, Signed);
        }
        catch (Exception exp)
        {
            System.Diagnostics.Debug.WriteLine("Verification Failed. Exception Occurred : {0}", exp.Message);
            // default result is false so drop through to exit.
        }
    
        return VerifyResult;
    }
