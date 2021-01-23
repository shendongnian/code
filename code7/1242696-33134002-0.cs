    public async Task StartAsync()
    {
        _cancelSource = new CancellationTokenSource();
        await UpdateAsync(_cancelSource.Token);
    }
    public async Task UpdateAsync(CancellationToken cancellationToken)
    {
        try
        {
             var updateSomething = Task.Run(() => _request.UpdateSomething()));
             var updateSomethingElse = Task.Run(() => _request.UpdateSomethingElse());
            await Task.WhenAll(updateSomething, updateSomethingElse);
        }
        catch (OperationCanceledException)
        {
            // Handle cancellation
        }
        catch (Exception exception)
        {
            // Handle exception
        }
        finally
        {
            if (_cancelSource.IsCancellationRequested)
                await Task.Delay(2000);
        }
    }
