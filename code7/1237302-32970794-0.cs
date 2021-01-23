      private static object getObjectModels(DbContext context, IQueryable<int> contractsID)
        {
             // Necessary to translate Contains to SQL IN  CLAUSE
            int [] contractIdsArray = contractsID.ToArray() ; 
    
            return (from objectModel in context.Set<ObjectModel>()
                    where contractIdsArray.Contains(objectModel.conId)
                    select new ContractHelper
                    {
                        Id = contract.Id,
                        ClientId = contract.ClientId,
                    });
        }
