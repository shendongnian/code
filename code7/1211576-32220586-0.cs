    using System.Security.Cryptography;
    ...
    public string MD5Hash(String input) {
      using (MD5 md5 = MD5.Create()) {
        return String.Concat(md5
          .ComputeHash(Encoding.UTF8.GetBytes(input))
          .Select(item => item.ToString("x2")));
      }
    }
    ...
    
    String hash = MD5Hash("Hello, World!");
