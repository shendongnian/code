     //Convert decrypted byte array to string
     string decryptedText = Encoding.Unicode.GetString(byteArray);
     //char[] chars = new char[byteArray.Length / sizeof(char)];
     //System.Buffer.BlockCopy(byteArray, 0, chars, 0, byteArray.Length);
     //string decryptedText = new string(chars);
     Console.WriteLine("Decrypted: " + decryptedText);
