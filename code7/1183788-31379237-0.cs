    foreach (var entry in files) // type of entry is "KeyValuePair<string,int>"
        {
            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "dll",  entry.Key)))
            { 
                 // Compare file size against entry.Value here.
                 // ...
            }
        }
    }
