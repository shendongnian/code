    public bool TryFindJob(string searchString,out PrintSystemJobInfo actualJob)
    {
        var myPrintServer = new PrintServer(@"\\theServer");
        actualJob=null;
        var myPrintQueues = myPrintServer.GetPrintQueues();
        foreach (PrintQueue pq in myPrintQueues)
        {
           pq.Refresh();
           var jobs = pq.GetPrintJobInfoCollection();
           foreach (PrintSystemJobInfo job in jobs)
           {
                if (job.JobName.Contains(searchString) || job.Name.Contains(searchString))
                {
                    actualJob=job;
                    return true;
                }
            }
        }
        return false;
    }
