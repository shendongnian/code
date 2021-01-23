    public static List<string> GetAllFilesOfAllDirectoriesCalledInput(string root)
    {
        List<string> inputDirectories = FindSubDirectoriesCalledInput(root);
        List<string> result = new List<string>();
        foreach(string inputDirectory in inputDirectories)
            result.AddRange(Directory.GetFiles(inputDirectory,"*.*", SearchOption.AllDirectories));
        return result;
    }
    public static List<string> FindSubDirectoriesCalledInput(string currentRoot)
    { 
        List<string> results = new List<string>();
        foreach(string subDirectory in Directory.GetDirectories(currentRoot))
        {
            if(subDirectory.EndsWith("\\Input", StringComparison.InvariantCultureIgnoreCase))
                results.Add(subDirectory);  
            else
                results.AddRange(FindSubDirectoriesCalledInput(subDirectory));
         }
         return results;
     }
        
