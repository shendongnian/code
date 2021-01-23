    [UnitOfWork]
    public async void Post(AdvertisementVM model)
    {
        CheckModelState();
        try
        {
            if (_unitOfWorkManager.Current == null)
            {
                using (var mgr = _unitOfWorkManager.Begin())
                {
                    await ExecuteMultipleDatabaseCalls(model);
                    await mgr.CompleteAsync();
                }
            }
            else
            {
                await ExecuteMultipleDatabaseCalls(model);
            }
        }
        catch (Exception ex)
        {
            throw new HttpException((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    private async Task ExecuteMultipleDatabaseCalls(AdvertisementVM model)
    {
        var retailer = _retailerAppService.GetForUser(model.UserId);
            
        var ad = new Advertisement
        {
            Message = model.Message,
            Title = model.Title,
            Retailer = retailer
        };
            
        await _adAppService.InsertOrUpdate(ad);
        await _unitOfWorkManager.Current.SaveChangesAsync();
    }
