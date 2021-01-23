    public async Task Process(CancellationTokenSource token)
    {
        await SpinUpServiceAsync();
        bool cancel;
        YourObject item;
        foreach (var i in LongList())
        {
            item = i;
            cancel = true;
            if (token.IsCancellationRequested) break;
            await LongTask1(item);
            if (token.IsCancellationRequested) break;
            await LongTask2(item);
            if (token.IsCancellationRequested) break;
            await LongTask3(item);
            if (token.IsCancellationRequested) break;
            await LongTask4(item);
            if (token.IsCancellationRequested) break;
            await LongTask5(item);
            cancel = false;
        }
        if (cancel)
        {
            Log($"Cancelled during {item}");
            await SpinDownServiceAsync();
            return;
        }
    }
