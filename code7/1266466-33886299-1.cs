    class Shift
    {
        public string Encrypt(string originalString, int shift)
        {
            string userOutput = "";
            char[] a = originalString.ToCharArray();
            for (int i = 0; i < originalString.Length; i++)
            {
                char c = a[i];
                int temp;
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    temp = (int)(a[i] + shift);
                    if ((c >= 'A' && c <= 'Z' && temp > 'Z') || (c >= 'a' && c <= 'z' && temp > 'z'))
                        temp = temp - 26;
                    else
                        temp = (int)(a[i] + (shift));
                }
                else
                    temp = c;
                userOutput += (char)temp;
            }
            return userOutput;
        }
        public string Decrypt(string cipherString, int shift)
        {
            return Encrypt(cipherString, -shift);
        }
    }
