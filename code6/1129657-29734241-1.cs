    byte[] key1 = ASCIIEncoding.ASCII.GetBytes("12345678");
    byte[] key2 = ASCIIEncoding.ASCII.GetBytes("abcdefgh");
                    
    string originalString = "A secret string";
    string cryptedString = Encrypt(Encrypt(originalString, key1), key2);
    Console.WriteLine("Encrypt message: {0}", cryptedString);
    Console.WriteLine("Decrypt message: {0}", Decrypt(Decrypt(cryptedString, key2), key1));
