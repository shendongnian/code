    using System;
    using System.Security.Cryptography;
    using System.Text;
    using Microsoft.SqlServer.Server;
    public class StoredProcedures
    {
      [SqlFunction]
      public static string GetMD5Hash (string input)
      {
        var encodedPassword = new UTF8Encoding().GetBytes(input);
        var hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
        return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
      }
    }
