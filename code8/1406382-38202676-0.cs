    string fullName = Path.Combine(uploadPath, name);
    using (var fs = ...)
    {
        // Code as before, but ideally taking note of the return value
        // of Stream.Read, that you're currently ignoring. Consider
        // using Stream.CopyTo
    }
    // Now the file will be closed
    using (var reader = File.OpenText(fullName))
    {
        // Read here
    }
