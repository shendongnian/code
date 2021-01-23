    using System.IO;
    using System.Security.Cryptography;
    ...
    //TODO: it's very time to rename "sig" into something more readable
    private static String sig(String fileName) {
      using (MD5 md5Hash = MD5.Create()) {
        using (FileStream stm = new FileStream(fileName, FileMode.Open)) {
          return String.Concat(md5Hash
            .ComputeHash(stm)
            .Select(b => b.ToString("X2")));
        }
      }
    }
