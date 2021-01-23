    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.Register(() =>
                _logger.LogDebug($"Background task is stopping."));
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogDebug($"Background task doing work.");
            DoTask();
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
