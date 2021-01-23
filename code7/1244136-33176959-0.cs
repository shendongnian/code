    static bool IsValidFileType(string filename, List<string> AcceptableExtensions)
    {
        string ext = Path.GetExtension(filename);
        
        foreach (string AccExt in AcceptableExtensions)
             if (ext.ToUpper() == AccExt.ToUpper())
                  return true;
       
        return false;
    }
