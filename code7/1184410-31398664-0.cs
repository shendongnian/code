    [ResponseType(typeof(CompaniesFullViewModel))]
    public async Task<HttpResponseMessage> Get() // Optionally Async suffix
    {
        var companies = await Repository.GetCompaniesAsync();
        var addresses = await Repository.GetAddressesAsync();
        HttpStatusCode statusCode = companies.Any()
             ? HttpStatusCode.OK
             : HttpStatusCode.PartialContent;
        return
            Request.CreateResponse(
                statusCode,
                new CompaniesFullViewModel
                {
                    Companies = companies,
                    Addresses = addresses
                });
    }
