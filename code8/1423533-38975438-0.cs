    public async Task<List<ClientSummaryModel>> GetClientSummaryCredit(string id)
    {
        return await WithConnection(async c =>
        {
            c.ChangeDatabase("PAQA");
            var summaryClientList =
                await c.QueryAsync<ClientSummaryModel>("dbo.SP_GET_CLIENT_SUMMARY",
                                                       new
                                                       {
                                                           Id = id,
                                                           SomeNumber = 0,
                                                           CashOrCredit = "CREDIT"
                                                       },
                                                       commandType: CommandType.StoredProcedure);
            return summaryClientList.ToList();
        });
    }
