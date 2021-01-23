    public async Task<object[]> GetChartData()
    {
        List<GoogleChartData> data;
        using (DBContext context = new DBContext ())
        {
            data = await context.Campaings.AsNoTracking().Take(10).Select(c => new GoogleChartData
            {
                Year = 2015,
                USA = 1,
                Mexico = 2,
                Canada = 3
            }).ToListAsync(); // Use ToListAsync()
        }
    
        // The rest are the same
    }
