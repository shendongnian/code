    string user1 = "daniel25";
    string user2 = "kevin91";
    var hashBuilder = new StringBuilder();
    hashBuilder.Append(user1);
    hashBuilder.Append(user2);
    var bytes = Encoding.Unicode.GetBytes(hashBuilder.ToString());
    byte[] hashBytes;
    using (var hasher = SHA1.Create())
    {
        hashBytes = hasher.ComputeHash(bytes);
    }
    long value = BitConverter.ToInt64(hashBytes, 12);
    var uniqueHash =  IPAddress.HostToNetworkOrder(value);
