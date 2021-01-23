       // Simplest, not thread safe
       private static string[] file;
    
       // line is one-based
       private static string[] getMyArray(int line) {
         if (null == file)
           file = File.ReadAllLines(@"C:\test.txt");
         // In case you have data in resource as string
         // read it and (split) from the resource
         // if (null == file)
         //   file = Resources.MyString.Split(
         //     new String[] { Environment.NewLine }, StringSplitOptions.None);
    
         string word = file
           .Skip(line - 1) // zero based line number
           .FirstOrDefault();
    
         if (null == word)
           return null; // or throw an exception
    
         return word
           .Select(c => c.ToString())
           .ToArray(); 
       } 
     
