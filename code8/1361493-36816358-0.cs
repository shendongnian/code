    public Stream GenerateStreamFromString(string s)
    {
         MemoryStream stream = new MemoryStream();
         StreamWriter writer = new StreamWriter(stream);
         writer.Write(s);
         writer.Flush();
         stream.Position = 0;
         return stream;
    }
    
    string publicKey = "-----BEGIN RSA PUBLIC KEY-----\nMIIBCAKCAQEAoNhWLaL11Zy4L6Cp2IDFv2JGnPkoRnFrKTy5b23uszzbSammdIwi\n6Wtr/7Zg3wmqlwt/yhH4F6rwSysB04xvMnWjuRsw2Kz4u7FHMPlgrIObGDFqcEms\nllNTA8xSWh/+TPfxWdAN5bpUwLYo6Mizl+VStL4CtVQFS8/mQSUnCju3csfxNGlk\nPQdbwZWB/5DdswrhkUcob8wl3bCCZCz3zWzMNJFTgTEiZQr+qTtuY7ST+fmpO33r\nDJoboysiGPKUkQixKcG2s1jJJkQircAHkmiQPS6PlUapNahFNaPa3rh1zR4l5NN6\nxWudPYQhZ8VvD4C8eT2bfrUlsikAyXIX4QIBAw==\n-----END RSA PUBLIC KEY-----\n"
    using (Stream stream = GenerateStreamFromString(publicKey))
    {
     
          PemReader pemReader = new PemReader(new StreamReader(stream));
          AsymmetricKeyParameter publicKey = (AsymmetricKeyParameter)pemReader.ReadObject();
          pemReader.Reader.Close();
          Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters rsaPub = (Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters)publicKey;
    
          RSAParameters RSAKeyInfo = Org.BouncyCastle.Security.DotNetUtilities.ToRSAParameters(rsaPub);
    
          RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);
          RSA.ImportParameters(RSAKeyInfo);
    
          byte[] encryptedData = RSA.Encrypt(plainText, true);
    }
