    CancellationTokenSource cts = new CancellationTokenSource();
    
    ParallelOptions parallelOptions = new ParallelOptions();
    parallelOptions.CancellationToken = cts.Token;
    parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
    
    Timer timer = new Timer(callback => { cts.Cancel(); }, null, 60*1000, Timeout.Infinite);
    
    try
    {
        Parallel.ForEach(concurentDictionary, parallelOptions, (item) =>
        {
            var mailObject = dbContext.MailObjects.Where(x => x.MailObjectId == item.key).Select(y => y);
            mailObject.MailBody = ConvertToPdf(item.Value.MailBody);
            parallelOptions.CancellationToken.ThrowIfCancellationRequested();
        });
    }
    catch (OperationCanceledException e)
    {
        // Log the cancellation event...
    }
    finally
    {
        dbContext.SaveChanges();
        cts.Dispose();
    }
