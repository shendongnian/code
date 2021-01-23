      int source = 123;
      byte[] hash;
      // Do not omit "using"
      using (var md5 = System.Security.Cryptography.MD5.Create()) {
        hash = md5.ComputeHash(BitConverter.GetBytes(source));
      }
      // Test
      // d119fabe038bc5d0496051658fd205e6
      Console.Write(String.Concat(hash.Select(x => x.ToString("x2"))));
