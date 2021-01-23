    class StatusProgress 
    {
        public string SystemName{get;set;}
        public string StatusString{get;set;}
        public int AvailableUpdatesCount {get;set;}
    }
    ....
    int sysCount=0;
    Parallel.ForEach(namelist, line =>
    {
        var progress=new StatusProgress();
        progress.SystemName = line;//file.ReadLine();
        Status.sVariables result = new Status.sVariables();
        result = OneSystem(line);
        switch (result.BGWResult)
        {
            case -1:
                progress.StatusString = "Login to server failed!";
                break;
                    //other status are assigned here;
        }
        var count=Interlocked.Increment(ref sysCount);
      }
      worker.ReportProgress(count, progress);
    });
