    List<string> stuffFromFile = new List<string>() { "1", "2", "3", "4" }; //contents
        
    while (stuffFromFile.Count > 0)
    {
        List<string> newChunk = stuffFromFile.Take(50).ToList(); //Take up to 50 elements
        stuffFromFile.RemoveRange(0, newChunk.Count); // Remove the elements you took
    }
