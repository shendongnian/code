    private static String Encrypt(String source, String key) {
      var dict = Encryptor(key);
      StringBuilder Sb = new StringBuilder(source.Length);
      Char sub;
      foreach (var ch in source)
        if (dict.TryGetValue(ch, out sub))
          Sb.Append(sub);
        else
          Sb.Append(ch);
      return Sb.ToString();
    }
     // Note, that Decryptor is the same as Encryptor by for the first line
    private static String Decrypt(String source, String key) {
      var dict = Decryptor(key);
      StringBuilder Sb = new StringBuilder(source.Length);
      Char sub;
      foreach (var ch in source)
        if (dict.TryGetValue(ch, out sub))
          Sb.Append(sub);
        else
          Sb.Append(ch);
      return Sb.ToString();
    }
