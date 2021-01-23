    public async Task Process()
    {
        int totalCount = returnedCol.total_count;
        while (totalCount > myDict.Count)
        {
            int numberOfTasks = // logic to calculate how many tasks to run
            List<Task> taskList = new List<Task>();
            for (int i = 1; i <= numberOfTasks; i++)
            {
                Interlocked.Add(ref pageNumber, pageSize);
                taskList.Add(ProcessPage(pageNumber, pageSize));
            }
            await Task.WhenAll(taskList.ToArray());
        }
     }
     private async Task ProcessPage(int pageNumber, int pageSize)
     {
           SearchResponse result = ExternalCall.GetData(pageNumber, pageSize);
           foreach (ExternalDataRecord dataiwant in result.dataiwant)
           {
               myDict.GetOrAdd(dataiwant.id, dataiwant);
           }
     }
