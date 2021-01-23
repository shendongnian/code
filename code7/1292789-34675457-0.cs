    // generate 20 random bytes
    Random rnd = new Random();
    Byte[] chksum = new Byte[20];
    rnd.NextBytes(chksum);
    
    // convert the byte array to a hex string representation
    var strchksum = BitConverter.ToString(chksum);
    // lowercase all hex characters and remove "-" characters
    strchksum = strchksum.ToLower().Replace("-", "");
    request.Headers.Add("X-APP-Checksum", strchksum);
