    var task1 = DB.ReadAsync("..").ContinueWith(task => {
       //Do A lot
       return Process(task.Result);  
    }, TaskScheduler.Default);
    
    var task2 = DB.ReadAsync("..").ContinueWith(task => {
       //Do A lot
       return Process(task.Result);  
    }, TaskScheduler.Default);
    
    var result = Combine(await task1, await task2);
