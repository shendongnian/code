    [ResponseType(typeof(CompaniesFullViewModel))]
    public async Task<HttpResponseMessage> Get() // async keyword. 
    {
        var companies = await Repository.GetCompaniesAsync(); // await
        var addresses = await Repository.GetAddressesAsync(); // await
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
