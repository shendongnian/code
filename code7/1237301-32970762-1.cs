    private static object getObjectModels(DbContext context, IQueryable<int> contractsID)
        {
            return (from objectModel in context.Set<ObjectModel>()
                    where objectModel.conId.HasValue && contractsID.Contains(objectModel.conId)
                    select new ContractHelper
                    {
                        Id = contract.Id,
                        ClientId = contract.ClientId,
                    });
        }
