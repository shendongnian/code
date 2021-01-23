    var cg = new List<string>();
    var type = "";
    
    var db = new MyDbContext();
    var list = new List<TopicViewModels>();
    
    if (cg != null && cg.Count > 0)
    {
       var tasks = new Task<List<TopicViewModels>>[13];
       byte i = 0;
    
       while (i < cg.Count)
       {
          string _cg = cg[i];
    
          tasks[i] = Task.Run(async () => 
          {
             // Isn't it possible that the where clause filters out and returns null?
             return await db.Topics
                            .Where(m => m.Type == type && m.Category == _cg)
                            .ToListAsync();
          });
    
          i++;
       }
        
       // Use await keyword to ensure that work is done
       var continuation = await Task.WhenAll(tasks.Where(t => t != null).ToArray());
    
       // never go to this loop...
       foreach (var topics in continuation.Result)
       {
          topics.ForEach(x => list.Add(x));
       }
    }
