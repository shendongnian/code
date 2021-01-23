    public static string ReadKey(string pubkeyFile)
    {
        string theKey;
        Stream fs = File.OpenRead(pubkeyFile);
    
        //
        // Read the public key rings
        //
        PgpPublicKeyRingBundle pubRings = new PgpPublicKeyRingBundle(PgpUtilities.GetDecoderStream(fs));
        fs.Close();
    
        return Convert.ToBase64String(pubRings.GetEncoded());
    }
