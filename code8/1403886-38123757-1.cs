    public class Condition
    {
        public bool Mandatory {get;set;}
        public string[] Extensions {get;set;}
    }
    // ...
    public string[] GetExtensions(IEnumerable<string> files)
    {
        return files.Select(f => Path.GetExtension(f)).Distinct().ToArray();
    }
    public bool AllConditionsOk(string[] fileNamesToCheck, Condition[] conditions)
    {
        //Extract Extension only (e.g. Path.GetExtension)
        string[] extensions = GetExtensions(fileNamesToCheck);
    
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
    }
