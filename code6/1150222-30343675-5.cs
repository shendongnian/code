    public void StartProcessing(/*input parameters*/,
                        CancellationTokenSource token,
                        IProgress<StatusProgress> progress)
    {
        .....
        var po=new ParallelOptions();
        po.CancellationToken=token;
        Parallel.ForEach(namelist, po,line =>
        {
           var status=new StatusProgress();
           status.SystemName = line;//file.ReadLine();
           Status.sVariables result = new Status.sVariables();
           result = OneSystem(line);
           switch (result.BGWResult)
           {
               case -1:
                   progress.StatusString = "Login to server failed!";
                   break;
                   //other status are assigned here;
           }
           progress.Report(status);
        }
    }
