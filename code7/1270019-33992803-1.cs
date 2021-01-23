    byte[] keyBytes = encoding.GetBytes(key);
    byte[] messageBytes = encoding.GetBytes(message);
    System.Security.Cryptography.HMACSHA256 cryptographer = new System.Security.Cryptography.HMACSHA256(keyBytes);
    cryptographer.Key = keyBytes;
    byte[] bytes = cryptographer.ComputeHash(messageBytes);
