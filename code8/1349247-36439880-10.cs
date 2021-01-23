    private static bool IsMultipartContentType(string contentType)
    {
        return 
            !string.IsNullOrEmpty(contentType) &&
            contentType.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) >= 0;
    }
    
    private static string GetBoundary(string contentType)
    {
        var elements = contentType.Split(' ');
        var element = elements.Where(entry => entry.StartsWith("boundary=")).First();
        var boundary = element.Substring("boundary=".Length);
        // Remove quotes
        if (boundary.Length >= 2 && boundary[0] == '"' && 
            boundary[boundary.Length - 1] == '"')
        {
            boundary = boundary.Substring(1, boundary.Length - 2);
        }
        return boundary;
    }
    private string GetFileName(string contentDisposition)
    {
        return contentDisposition
            .Split(';')
            .SingleOrDefault(part => part.Contains("filename"))
            .Split('=')
            .Last()
            .Trim('"');
    }
