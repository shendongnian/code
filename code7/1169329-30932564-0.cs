    string newFilenameExtension = Path.GetExtension("Sample".Trim());
    string extn = string.Empty;
    
    if (!String.IsNullOrWhiteSpace(newFilenameExtension))
    {
          extn = newFilenameExtension.Substring(1);
    }
    if(!String.IsNullOrWhiteSpace(extn))
    {
          // Use extn here
    }
