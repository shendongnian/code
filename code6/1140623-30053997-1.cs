    //with semaphore
    var semaphore = new Semaphore(0,2);
    for(long key = 0; key < 5; key++)
    {
        semaphore.WaitOne();
        var processingTask = Task.Run(() => DoDataSetup(key));
        _progress = new ProgressReport(processingTask);
        _progress.Show();
        _progress.FormClosed += delegate(object delSender, FormClosedEventArgs args)
        {
            this.Enabled = true;
        };
        this.Enabled = false;
        semaphore.Release();
    }
    //with TPL-Library using BatchBlock
    var actionBlock = new ActionBlock<long>( /* define bulk action here */);
    var batchBlock = new BatchBlock<long>(2);
    batchBlock.LinkTo(actionBlock)
    for(long key = 0; key < 5; key++)
    {
        batchBlock.Post(() => DoDataSetup(key));
    }
