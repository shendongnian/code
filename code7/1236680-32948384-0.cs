    private static byte[] Crypt
      (byte[] data, byte[] key, byte[] iv, ICryptoTransform cryptor)
    {
      MemoryStream m = new MemoryStream();
      using( Stream c = new CryptoStream(m, cryptor, CryptoStreamMode.Write ))
      {
        c.Write(data, 0, data.Length);
      }
      return m.ToArray();
    }
    public static byte[] Encrpyt(byte[] data, byte[] key, byte[] iv)
    {
      using( Aes algorithm = Aes.Create())
      using( ICryptoTransform encryptor = algorithm.CreateEncryptor(key,iv))
      {
        return Crypt( data, key, iv, encryptor );
      }
    }
