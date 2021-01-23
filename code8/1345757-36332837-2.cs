    private void GenerateRecords(JobRequest request)
    {
        Parallel.For(0, daysInRange, day =>
        {
            foreach (var coreId in request.CoreIds)
            {
                for (var i = 0; i < request.AgentsCount; i++)
                {
                    var agentId = Guid.NewGuid();
                    for (var copiesDone = 0; copiesDone < request.CopiesToMake; copiesDone++)
                    {
                        foreach (var jobInfoRecord in request.Jobs)
                        {
                            foreach (var status in request.Statuses)
                            {
                                //DoSomeWork();
                            }
                        }
                    }
                }
            }
        });
    }
