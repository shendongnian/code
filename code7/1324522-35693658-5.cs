        static string Decrypt(string cipherText, string key)
        {
            char[] chars = new char[cipherText.Length];
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (cipherText[i] == ' ')
                {
                    chars[i] = ' ';
                }
                else
                {
                    int j = Char.IsUpper(cipherText[i]) ? key.IndexOf(Char.ToLower((char)cipherText[i])) + 'a' : key.IndexOf(cipherText[i]) + 'a';
                    chars[i] = Char.IsUpper(cipherText[i]) ? Char.ToUpper((char)j) : (char)j;
                }
            }
            return new string(chars);
        }
