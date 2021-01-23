    string hex = "0BC9C82C5600A2448592D4E21285E292A2CCBC74454500";
    //credits: http://stackoverflow.com/a/321404/5089204
    var byteArray = Enumerable.Range(0, hex.Length / 2)
                                .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
                                .ToArray();
    int batchSize = 32768;
    byte[] buf = new byte[batchSize];
    using (MemoryStream result = new MemoryStream()) {
        using (DeflateStream deflateStream = new DeflateStream(new MemoryStream(byteArray), CompressionMode.Decompress)) {
            int bytesRead;
            while ((bytesRead = deflateStream.Read(buf, 0, batchSize)) > 0)
                result.Write(buf, 0, bytesRead);
        }
    }
    string s = System.Text.Encoding.Default.GetString(buf);
    
