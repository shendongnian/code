    public async Task PerformCheckout(int salesAddressId)
    {
        try
        {
            ...
            ...
            // We just made a sale. Send emails to all market owners.
            await SendSalesEmailsAsync(master);
        }
        catch (System.Exception exception)
        {
            // Log the error
        }
