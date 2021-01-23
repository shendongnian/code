    protected override void OnViewLoaded(object view)
    {
        var runningTasks =  _myMefClasses.Select(m=>m.Start()).ToArray();
        try
        {
            Task.WaitAll(runningTasks);
        }
        catch(AggregateException ex)
        {
            //Any exception raised by a task will be in ex.InnerExceptions
        }
    }
