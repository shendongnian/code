        foreach (char c in encryptedData)
        {
            if (c == ' ')
            {
                Console.Write(" ");
            }
            else
            {
                int charPosition = 0;
                charPosition = Array.IndexOf(alphabet, c);
                if (charPosition == -1)
                {//Check for non expected items
                    Console.Write("*");
                }
                else
                {
                    charPosition = charPosition - 5;
                    if (charPosition < 0)
                    {
                        charPosition = charPosition + 26;
                    }
                    Console.Write(alphabet[charPosition]);
                }
            }
        }
