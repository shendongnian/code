    var keys = new HashSet<string>();
    foreach (line in file) {
        string[] parts = line.Split(',');
        keys.Add(parts[0];
    }
    foreach (newKey in newKeys) {
        if (keys.Contains(newKey)) {
            // Item already exists
            ...
        } else {
            // New item
            keys.Add(newKey);
            ...
        }
    }
