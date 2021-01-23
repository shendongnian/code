    public static bool Verify(System.Security.Cryptography.X509Certificates.X509Certificate2 cert, string messageToCheck, string signature) {
        var retval = false;
        var ci = new ContentInfo(Encoding.UTF8.GetBytes(messageToCheck));
        var cms = new SignedCms(ci, true);
        cms.Decode(Convert.FromBase64String(signature));
        // Check whether the expected certificate was used for the signature.
        foreach (var s in cms.SignerInfos) {
            if (s.Certificate.Equals(cert)) {
                retval = true;
                break;
            }
        }
        // The following will throw if the signature is invalid.
        cms.CheckSignature(true);
        return retval;
    }
