    string originalVNI = "ĐŨHello";
    Console.WriteLine("Original: {0}", originalVNI);
    try
    {
        var vni = new VNIWindowsEncoding();
        var iso8859 = Encoding.GetEncoding("iso-8859-1");
    
        // You should have something like the content of encodedVNI in 
        // ems.Nguoi_goi... so a string encoded in VNI, with characters
        // with diacritics that are expanded to character pair
        string encodedVNI = iso8859.GetString(vni.GetBytes(originalVNI));
        Console.WriteLine("Encoded in VNI encoding: {0}", encodedVNI);
    
        // First you have to reconvert encodedVNI to a byte[]
        byte[] byteArray = iso8859.GetBytes(encodedVNI);
    
        // Then you can convert it to a byte[]
        byte[] res = Encoding.Convert(vni, Encoding.UTF8, byteArray);
            
        // Let's check:
        Console.WriteLine("Encoded to UTF8 and then decoded: {0}", Encoding.UTF8.GetString(res));
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception: {0}", ex);
    }
