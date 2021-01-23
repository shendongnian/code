    [Route("api/Deliveries/Count")] 
    public async Task<int> GetCountOfDeliveryRecords()
    {
        return await NRBQService.GetNRBQEntity();
    }
