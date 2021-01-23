    var stopwatch = Stopwatch.StartNew();
    var progressImpl=new Progress<Tuple<int,string,string>>(
                         msg=>ReportProgress(msg,stopwatch))
    IProgress<Tuple<int,string,string>> progress=progressImpl;
    var  partitioner = Partitioner.Create(query, EnumerablePartitionerOptions.NoBuffering);
    Task.Run(()=> Parallel.ForEach(partitioner, thisCheck =>
                {
                 .... 
                 var msg=Tuple.Create(iChckNo,thisCheck.VoucherNumber,thisCheck.EmployeeName);
                 progress.Report(msg);
                 ...
                })
            );
     ...
    private void ReportProgress(Tuple<int,string,string> msg,Stopwatch stopwatch)
    {
        _status.ProcessMsg = "Voucher " + msg.Item2;
        _status.ProcessName = msg.Item3;
        _status.CurrentRec = msg.Item1;
        _status.TimeMsg = string.Format("Elapsed {0:c}", stopwatch.Elapsed);
    };
