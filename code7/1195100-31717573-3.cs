    static string[] SearchFiles(string[] filesSrc, string searchTerm)
    {
       List<string> result = new List<string>();
       string line = "";
    
       for(int i = 0; i < filesSrc.Length; i++)
       {
          using(StreamReader reader = new StreamReader(filesSrc[i]))
          {
             while ((line = reader.ReadLine()) != null)
                if (line.Contains(searchTerm)) { result.Add(filesSrc[i]); break;}                      
          }
       }
       return result.ToArray();
    }
