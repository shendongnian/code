    try
    {
    }
    catch(TaskCanceledException)
    {
        if(!cts.Token.IsCancellationRequested)
        {// timeout
        }
        else
        {//other reason
        }
    }
