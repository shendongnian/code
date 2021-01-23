    var dictionary = File.ReadLines("Test.csv")
                         .Select(Entry.FromCsv) // Static method in the Entry class
                         .ToDictionary(e => e.Name);
    ...
    // Looking up by name
    Entry entry;
    if (dictionary.TryGetValue(name, out entry))
    {
        // Now use entry, with all the relevant properties
    }
