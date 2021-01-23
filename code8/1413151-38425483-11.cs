    foreach (var name in reader.ReadAllSubtrees("InformationTuples", "")
        .SelectMany(r => r.ReadAllSubtrees("InformationTuple", ""))
        .Select(r => r.ReadAllElementContentsAsString("Name", "").First()))
    {
        // Process the name somehow
        Debug.WriteLine(name);
    }
