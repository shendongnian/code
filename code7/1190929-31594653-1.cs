    while ((line = reader.ReadLine()) != null)
    {
        foreach (var searchable in searchables)
        {
            if (line.Contains(searchable.searchTerm))
            {
                searchable.counter++;                     
            }
        }
    }
