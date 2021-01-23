    foreach (var name in reader.ReadAllSubtrees("InformationTuple", "")
        .SelectMany(r => r.ReadAllElementContentsAsString("Name", "").Take(1)))
    {
        // Process the name somehow
        Debug.WriteLine(name);
    }
