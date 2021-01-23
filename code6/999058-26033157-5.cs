    public static string ReadKey(string pubkeyFile)
    {
        Stream fs = File.OpenRead(pubkeyFile);
    
        //
        // Read the public key rings
        //
        PgpPublicKeyRingBundle pubRings = new PgpPublicKeyRingBundle(PgpUtilities.GetDecoderStream(fs));
        fs.Close();
        foreach (PgpPublicKeyRing pgpPub in pubRings.GetKeyRings())
        {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (ArmoredOutputStream aos = new ArmoredOutputStream(ms))
                        pgpPub.Encode(aos);
                    return System.Text.Encoding.ASCII.GetString(ms.ToArray());
                }
        }
        return null;
    }
