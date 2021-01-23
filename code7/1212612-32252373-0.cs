    bool isArchive(string filename)
    {
        if (!string.IsNullOrEmpty(filename))
        {
            var lowercaseExt = System.IO.Path.GetExtension(filename).ToLowerInvariant();
            return new[]{ ".zip", ".7z", ".rar"/*, ...*/}.Contains(lowercaseExt);
        }
        return false;
    }
