    using (var reader = new StreamReader(theStream))
    {
        string message = reader.ReadLine();
        
        // Or in an async method
        string message = await reader.ReadLineAsync();
    }
    
