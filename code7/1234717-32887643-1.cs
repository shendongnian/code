    for(int i=0; i < jobList.Count(); i++)
    {
        tasks[i] = Task.Run(() => ProcessJob(jobList[i]));
    }
        
    try
    {
       await Task.WhenAll(tasks);
    }
    catch(Exception ex)
    {
       // handle exception
    }
