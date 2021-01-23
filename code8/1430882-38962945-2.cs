    public string CheckHash(string filename, string algorithm)
    {
        using (var stream = File.OpenRead(filename))
        {
            using (var algorithm = (HashAlgorithm)CryptoConfig.CreateFromName(algorithm)) 
            {
                return ConvertHashToString(algorithm.ComputeHash(stream));
            }
        }
    }
