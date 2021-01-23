    RSA existingKey = HoweverYouWereGettingAKey();
    RSAParameters rsaParams = existingKey.ExportParameters(false);
    BigInteger n = PrepareBigInteger(rsaParams.Modulus);
    BigInteger e = PrepareBigInteger(rsaParams.Exponent);
    BigInteger sig = PrepareBigInteger(signature);
    BigInteger paddedMsgVal = BigInteger.ModPow(sig, e, n);
    byte[] paddedMsg = paddedMsgVal.ToArray();
    
    if (paddedMsg[paddedMsg.Length - 1] == 0)
    {
        Array.Resize(ref paddedMsg, paddedMsg.Length - 1);
    }
    Array.Reverse(paddedMsg);
    // paddedMsg is now ready.
    private static BigInteger PrepareBigInteger(byte[] unsignedBigEndian)
    {
        // Leave an extra 0x00 byte so that the sign bit is clear
        byte[] tmp = new byte[unsignedBigEndian.Length + 1];
        Buffer.BlockCopy(unsignedBigEndian, 0, tmp, 1, unsignedBigInteger.Length);
        Array.Reverse(tmp);
        return new BigInteger(tmp);
    }
