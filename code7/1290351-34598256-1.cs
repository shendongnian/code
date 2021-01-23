    using (var writer = new StreamWriter(theStream))
    {
        writer.WriteLine(theMessage);
    
        // Or in an async method
        await writer.WriteLineAsync(theMessage);
    }
