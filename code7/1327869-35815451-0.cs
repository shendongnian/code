    private async Task SeedingProd(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            int totalSeeded = 0;
            var codesToSeed = await _myRepository.All().ToListAsync(token);
            foreach (var code in codesToSeed)
            {
                if (token.IsCancellationRequested)
                    return;
                    
                try
                {
                    int seedCountByCode = await _myManager.SeedDataFromLive(code);
                    totalSeeded += seedCountByCode;
                }
                catch (Exception ex)
                {
                    _logger.InfoFormat(ex.ToString());
                }
            }
            
            await Task.Dealy(30000);
        }
    }
    
