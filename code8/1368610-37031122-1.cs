    // Using statements (for BouncyCastle)
    using Org.BouncyCastle.Crypto.Digests;
    using Org.BouncyCastle.Crypto.Generators;
    // Define your byte[]s
    byte[] result = new byte[1];
    byte[] data = new byte[2];
    byte[] key = new byte[3];
    // Build your HMac, Generator and generate your bytes
    HMac hMac = new HMac(new Sha256Digest());
    Kdf1BytesGenerator g = new Kdf1BytesGenerator(hMac.GetUnderlyingDigest());
    g.Init(new Org.BouncyCastle.Crypto.Parameters.KdfParameters(key, data));
    g.GenerateBytes(result, 0, result.Length);
