    var message = new byte[] { 1, 2, 3 };
    var s = new byte[32];
    byte[] m;
    byte[] x;
    
    using (HashAlgorithm sha256 = SHA256.Create())
    {
        m = sha256.ComputeHash(message);
    }
    
    using (IncrementalHash sha256 = IncrementalHash.CreateHash(HashAlgorithmName.SHA256))
    {
        sha256.AppendData(m);
        sha256.AppendData(s);
        x = sha256.GetHashAndReset();
    }
