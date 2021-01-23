    private const int maxLength = 2083;
    public List<string> EncryptList<T>(List<T> list)
    {
        List<string> encryptedLists = new List<string>();
        string encrypted = PerformEncryption();
        if (encrypted.Length > maxLength)
        {
            encryptedLists.AddRange(EncryptList<T>(list.Take(list.Count / 2).ToList()));
            encryptedLists.AddRange(EncryptList<T>(list.Skip(list.Count / 2).ToList())); 
        }
        else
        {
            encryptedLists.Add(encrypted);
        }
        return encryptedLists;
    }
