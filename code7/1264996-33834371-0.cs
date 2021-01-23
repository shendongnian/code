    foreach (var term in termDocumentIncidenceMatrix)
    {
        // Print the string (your key)
        Console.WriteLine(term.Key);
    
        // Print each int in the value
        foreach (var i in term.Value)
        {
            Console.WriteLine(i);
        }
    }
