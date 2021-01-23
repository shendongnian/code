    public async Task MyCallingFunction()
    {
        Console.WriteLine("Function Starting");
        Task saveTask = SaveRecords(GenerateNewRecords());
    
        for(int i = 0; i < 1000; i++){
            Console.WriteLine("Continuing to execute!");
        }
        
        await saveTask;
        Console.Log("Function Complete");
    }
