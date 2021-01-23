    var testData = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
    var inputStream = new MemoryStream(testData);
    
    var inputAsString = Convert.ToBase64String(inputStream.ToArray());
    Console.WriteLine(inputAsString);
    
    var outputStream = new MemoryStream(Convert.FromBase64String(inputAsString));
    
    var result = BitConverter.ToString(outputStream.ToArray());           
    Console.WriteLine(result);
