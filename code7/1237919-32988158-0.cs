    private static IQueryable<Contract> getValidContracts(DbContext context, DateTime date, int clientId)
    {
    	var query = context.Set<Contract>().Where(contract => contract.ValidityDate >= date);
    	if (clientId != 0)
    		query = query.Where(contract => contract.ClientId == clientId);
    	return query; 
    }
