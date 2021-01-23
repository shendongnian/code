    int numOfThreads = System.Environment.ProcessorCount;
    // int numOfThreads = X;
    for(int i =0; i< numOfThreads; i++)
    task.Add(Task.Factory.StartNew(()=> {});
    while(task.count>0) //wait for task to finish
    {
          int index = Task.WaitAny(tasks.ToArray());
          tasks.RemoveAt(index);
          if(incomplete work)
          task.Add(Task.Factory.StartNew()=> {....});
    }
