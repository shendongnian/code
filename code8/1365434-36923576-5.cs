    Task[] tasks = new Task[2];
    // run task[1]
    tasks[0] = Task.Run(() => {
        SomeClass Object1  = new SomeClass();
        while (true)
        {
            if(tasks[1].IsCompleted)
            {
                return;
            }
        }
    
    },token);  
  
