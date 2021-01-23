        static string Encrypt(string plainText, string key)
        {
            char[] chars = new char[plainText.Length];
            for (int i = 0; i < plainText.Length; i++)
            {
                if (plainText[i] == ' ')
                {
                    chars[i] = ' ';
                }
                else if (Char.IsUpper(plainText[i]))
                {
                    int j = plainText[i] - 'A';
                    chars[i] = key[j];
                }
                else
                {
                    int j = plainText[i] - 'a';
                    chars[i] = key[j];
                }
            }
            return new string(chars);
        static string Decrypt(string cipherText, string key)
        {
            char[] chars = new char[cipherText.Length];
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (cipherText[i] == ' ')
                {
                    chars[i] = ' ';
                }
                else if (Char.IsUpper(cipherText[i]))
                {
                    int j = key.IndexOf(cipherText[i]) - 'A';
                    chars[i] = (char)j;
                }
                else
                {
                    int j = key.IndexOf(cipherText[i]) - 'a';
                    chars[i] = (char)j;
                }
            }
            return new string(chars);
        }
