    using System.IO;
    using System.Security.Cryptography;
    
    using (HashAlgorithmalgorithm = new .SHA512Managed())
    {
        using (Stream fileStream = new FileStream(@"path", FileMode.Open))
        {
            byte[] hash = algorithm.ComputeHash(fileStream);
        }
    }
