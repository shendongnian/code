    var tasks = new List<Task>();
    
    for(var item in items) 
    { 
      var task = dbAccess.DeleteAsync(item.id)
                 .ContinueWith(antecedent => dbAccess.SaveAsync(item))
    
      tasks.Add(task); 
    }
    
    await Task.WhenAll(tasks);
