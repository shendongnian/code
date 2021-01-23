    IEnumerable<string> ReadFile(string path)
    {
     using (var reader = new StreamReader(path))
      {
        while (!reader.EndOfStream)
        {
         yield return reader.ReadLine();
        }
      }
    }
    
    
    void DoThing() 
    {
      var myMethods = new Action<string>[] 
        { 
          s => 
             {
               //Process 0            
               type = line.Substring(0, 15);
               name = line.Substring(15, 30);
               //... and more 20 substrings
             },
          s => 
             {
               //Process 1            
               type = line.Substring(0, 15);
               name = line.Substring(15, 30);
               //... and more 20 substrings
             },
                //...
          
        }
    
    var actions = ReadFile(@"c:\path\to\file.txt")
          .Select(line => new Action( () => myMethods[int.Parse(line[0])]() ))
          .ToArray();
    
     actions.ForEach(a => a.Invoke());
    }
