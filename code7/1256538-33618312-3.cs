    while (idxMin < max)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();
            ....
        }
        catch (JobAbortedException jobEx)
        {
            ....
        }
    }
