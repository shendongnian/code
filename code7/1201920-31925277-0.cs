    var loans = unitOfWork.Context.Loans.AsNoTracking().ToLookup(o=>o.Client_Id);
    var clientAccount = unitOfWork.Context.ClientAccounts.AsNoTracking().ToList();
    foreach(var cilent in clientAccount)
    {
        client.Loans = loans[Client.ID].ToArray();
    }
