    public static string ReadKey(string pubkeyFile)
    {
        string theKey;
        Stream fs = File.OpenRead(pubkeyFile);
    
        //
        // Read the public key rings
        //
        PgpPublicKeyRingBundle pubRings = new PgpPublicKeyRingBundle(PgpUtilities.GetDecoderStream(fs));
        fs.Close();
        foreach (PgpPublicKeyRing pgpPub in pubRings.GetKeyRings())
        {
            byte[] keyData = pgpPub.GetEncoded();
            theKey = Convert.ToBase64String(keyData);
        }
        return theKey;
    }
