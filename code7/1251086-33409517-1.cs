      int source = 123;
      String hash;
      // Do not omit "using"
      using (var md5 = System.Security.Cryptography.MD5.Create()) {
        hash = String.Concat(md5.ComputeHash(BitConverter
          .GetBytes(source))
          .Select(x => x.ToString("x2")));
      }
      // Test
      // d119fabe038bc5d0496051658fd205e6
      Console.Write(hash);
