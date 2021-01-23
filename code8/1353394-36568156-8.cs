    string originalStr = "This is a test string!!";
    byte[] data = Encoding.ASCII.GetBytes (originalStr);
    SqlBytes sbCompressed = BinaryCompress (new SqlBytes (data));
    
    string a = GetHexaStringFromBinary (sbCompressed.Value);
    //a = 0x0BC9C82C5600A2448592D4E21285E292A2CCBC74454500
    
    var sqlBytes = new SqlBytes(GetBinaryFromHexaString (a));
    SqlBytes deCompressed = BinaryDecompress (sqlBytes);
    string finalStr = Encoding.ASCII.GetString (deCompressed.Value);
    //finalStr = "This is a test string!!"
