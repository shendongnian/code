    public static bool VerifySignature(string data, string signatureText)
    {
        // Using statements and error checking removed for brevity 
        var uri = new Uri("pack://application:,,,/Resources/public.pem");
        var resourceStream = Application.GetResourceStream(uri);
        var reader = new StreamReader(resourceStream.Stream);
        PemReader pemReader = new PemReader(reader);
        RsaKeyParameters parameters = (RsaKeyParameters)pemReader.ReadObject();
        RsaDigestSigner signer = (RsaDigestSigner)SignerUtilities.GetSigner("SHA-256withRSA");
        signer.Init(false, parameters);
        byte[] sigBytes = Convert.FromBase64String(signatureText);
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        signer.BlockUpdate(dataBytes, 0, dataBytes.Length);
        bool isValid = signer.VerifySignature(sigBytes);
        return isValid;
    }
