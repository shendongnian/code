    var name=Path.GetFileNameWithoutExtension(file);
    PrintSystemJobInfo job;
    if(TryFindJob(name,out job))
    {
       while(...)
       {
            job.Refresh();
            if (job.IsCompleted)
            {
                break;
            }
            else
            {
                //Sleep and retry
            }
         
    }
