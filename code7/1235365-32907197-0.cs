    public string DecryptString(string cipherText)
        {
            GenerateIV();
            GenerateKey();
            if (cipherText == null || cipherText.Length <= 0)
