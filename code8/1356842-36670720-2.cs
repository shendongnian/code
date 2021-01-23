    string box = "iNEpgwFIo6nyaLNgMpSWqwTQ9Z5y/y+BUXszXVFZ2gP2A3XJ0Q==";
    string key = "FKpCo/AhRRUjdQIpzMbZSnnzfBx1e/Ni9VZyNWYEB8E=";
    string nonce = "2qngWbMLFVNiPTFqTVO9nsraB8ACIrwV";
    try
    {
        //Libsodium-net SecretBox.Open() requires a 16 byte authentication tag at the start of the ciphertext
        //TweetNaclFast boxing method does not append a 16 byte authentication tag anywhere
        //Thus, we need to add a 16 byte authentication tag at the start of ciphertext encripted by TweetNaclFast
        byte[] authenticationTag = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //Zeroed 16 Bytes Authentication Tag
        byte[] tweetNaclFastCiphertextBytes = Convert.FromBase64String(box);
        byte[] libsodiumNetLikeCiphertext = new byte[tweetNaclFastCiphertextBytes.Length + authenticationTag.Length];
        Array.Copy(authenticationTag, libsodiumNetLikeCiphertext, authenticationTag.Length);
        Array.Copy(tweetNaclFastCiphertextBytes, 0, libsodiumNetLikeCiphertext, authenticationTag.Length, tweetNaclFastCiphertextBytes.Length);
        byte[] nonceBytes = Convert.FromBase64String(nonce);
        byte[] keyBytes = Convert.FromBase64String(key);
        Console.WriteLine(Encoding.UTF8.GetString(Sodium.SecretBox.Open(libsodiumNetLikeCiphertext, nonceBytes, keyBytes)));
    }
    catch (CryptographicException e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);
    }
