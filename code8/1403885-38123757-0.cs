    class Condition
    {
        bool Mandatory {get;set;}
        string[] Extensions {get;set;}
    }
    string[] fileNamesToCheck = "List of Files";
    //Extract Extension only (e.g. Path.GetExtension)
    string[] extensions = GetExtensions(fileNamesToCheck).Distinct().ToArray();
    
    //Check if any existing extension is not allowed
    foreach(string extension in extensions)
    {
        if(!conditions.Any(c => c.Extensions.Contains(extension)))
            return false;
    }
    //Check if every mandatory condition is fulfilled
    foreach(Condition condition in conditions.Where(c => c.Mandatory))
    {
         if(!condition.Extensions.Any(e => extensions.Contains(e)))
             return false;
    }
    return true;
