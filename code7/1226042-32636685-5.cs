    // Cache the instance for performance benefits.
    static readonly Regex regex = new Regex(@"^[aA-zZ]{2}\/$", RegexOptions.Compiled);
    /// <summary>
    /// Regex to check if Url segments have the 2 letter 
    /// ISO code as first ocurrance after root
    /// </summary>
    private bool IsLocaleEnabled(Uri sourceUri)
    {
      // Update: Compiled regex are way much faster than using non-compiled regex.
      return regex.IsMatch(sourceUri.Segments[1]);
    }
