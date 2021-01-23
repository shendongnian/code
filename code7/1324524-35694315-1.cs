    private static Dictionary<Char, Char> Encryptor(String key) {
      Char[] data = key.ToArray();
      Char[] sorted = data.OrderBy(c => c).ToArray();
      return data
        .Zip(sorted, (plain, encrypted) => new {
             Plain = plain,
             Encrypted = encrypted
         })
        .ToDictionary(item => item.Plain, item => item.Encrypted);
    }
    // Note, that Decryptor is the same as Encryptor by for the last line
    private static Dictionary<Char, Char> Decryptor(String key) {
      Char[] data = key.ToArray();
      Char[] sorted = data.OrderBy(c => c).ToArray();
      return data
        .Zip(sorted, (plain, encrypted) => new {
          Plain = plain,
          Encrypted = encrypted
        })
        .ToDictionary(item => item.Encrypted, item => item.Plain);
    }
