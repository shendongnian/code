    var jsonString = "";
    var jsonSerializer = new DataContractJsonSerializer(typeof(House));
    
    using (var memoryStream = new MemoryStream())
    using (var streamReader = new StreamReader(memoryStream))
    {
        jsonSerializer.WriteObject(memoryStream, myHouse);
        memoryStream.Position = 0;
        jsonString = streamReader.ReadToEnd();
    }
    Console.Write("JSON form of Person object: ");
    Console.WriteLine(jsonString);
