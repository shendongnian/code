    var task1 = Task.Factory.StartNew(async ()=> //NO AWAIT
    {
       var records = DB.Read("....."); //NO ASYNC
       //Do A lot
       result1 = Process(records);  
    });
    ... another task definition
    Task.WaitAll(task1, task2);
