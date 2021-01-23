     private void GetTokensFromJson(string filePath)
                {
                    IEnumerable<string> txts = File.ReadLines(filePath, Encoding.UTF8);
        List<JObject> jObjects = new List<JObject>() {};
        IList<string> keyslist;
        
                    Console.WriteLine(txts.Count());
        
                    List<string> distinctKeys = new List<string>();
        
                    foreach (var text in txts)
                    {
        
                          var obj = JObject.Parse(text); 
                          jObjects.add(obj);  
                       
        
                    }
        for each ( jobject in jobjects )   
        {
         IList<string> keys = jobject .Properties().Select(p => p.Name).ToList();
        keyslist.add(keys);
        }
        keyslist.distinct();
        
             }
