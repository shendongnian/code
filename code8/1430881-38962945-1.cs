    private string CheckHash(string filename, HashAlgorithm algorithm)
    {
        using (var stream = File.OpenRead(filename))
        {
            using (algorithm) 
            {
                return ConvertHashToString(algorithm.ComputeHash(stream));
            }
        }
    }
    public string CheckMd5(string filename) => CheckHash(filename, MD5.Create());
    public string CheckSha512(string filename) => CheckHash(filename, SHA512.Create());
