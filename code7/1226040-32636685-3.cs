    /// <summary>
    /// Regex to check if Url segments have the 2 letter 
    /// ISO code as first ocurrance after root
    /// </summary>
    private bool IsLocaleEnabled(Uri sourceUri)
    {
       return Regex.IsMatch(sourceUri.Segments[1], @"^[aA-zZ]{2}\/$");
    }
