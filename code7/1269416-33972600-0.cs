    List<Task<string>> processTasks = new List<Task<string>>();
    
    for(int i = 0; i < 130; i ++)
    {
            Task<string> processTask = Task<string>
            (
                () => 
                {
                     // System.Diagnostics.Process stuff goes here, you should return a string
                     // since it represents the output of the whole process
                }
            );
             
            processTasks.Add(processTask);
            Task.Run(processTask);
    }
    
    // Asynchronously wait for all tasks to finish
    await Task.WhenAll(processTasks);
    
    // Now after all tasks have finished, each stored task in "processTasks" 
    // will contain a task where their "Result" property is the string representing
    // the whole process output
