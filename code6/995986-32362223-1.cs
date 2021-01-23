    private void ParallelInserts()
    {
        ..
        //Other code in the method
        ..
    
        //Read first csv into memory. It's just a GB so should be fine
        ReadFirstCSV();
    
        //Read second csv into memory...
        ReadSecondCSV();
    
        //Because the inserts will last more than a few CPU cycles...
        var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None)
    
        //An array to hold the two parallel inserts
        var insertTasks = new Task[2];
    
        //Begin insert into first table...
        insertTasks[0] = taskFactory.StartNew(() => InsertInto(commandStringFirst, connectionStringFirst));
    
        //Begin insert into second table...
        insertTasks[1] = taskFactory.StartNew(() => InsertInto(commandStringSecond, connectionStringSecond));
    
        //Let them be done...
        Task.WaitAll(insertTasks);
    
        Console.WriteLine("Parallel insert finished.");
    }
    
    //Defining the InsertInto method which we are passing to the tasks in the method above
    private static void InsertInto(string commandString, string connectionString)
    {
        using (/*open a new connection using the connectionString passed*/)
        {
            //In a while loop, iterate until you have 100/200/500 rows
            while (fileIsNotExhausted)
            {
                using (/*commandString*/)
                {
                    //Execute command to insert in bulk
                }
            }
        }
    }
