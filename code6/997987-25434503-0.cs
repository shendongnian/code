    // The resource will be a byte array, I'm just creating a
    // byte array manually for example purposes.
    var fileData = System.Text.Encoding.UTF8.GetBytes("Hello\nWorld!");
    
    using (var memoryStream = new MemoryStream(fileData))
    using (var streamReader = new StreamReader(memoryStream))
    {
        // Do whatever you need with the file's contents
        Console.WriteLine(streamReader.ReadLine());
        Console.WriteLine(streamReader.ReadLine());
    }
