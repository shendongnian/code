    public async Task UpdateContractWithRepository(ViewModel viewModel)
    {
        // Get the contract from db
        Contract contract = GetContract(viewModel.Id);
    
        if (viewModel.RepositoryId == null)
        {
            if (contract.RepositoryId == null)
            {
                // nothing to do
                // no change
            } else {
                // Unassign Repository
                UpdateRepositoryAssignment(contract.RepositoryId, false);
    
                // Update properties
                contract.RepositoryId = null;
                contract.ConsumedUnits = null;
            }
        } else {
            if (contract.RepositoryId == null)
            {
                // assign repository
                UpdateRepositoryAssignment(viewModel.RepositoryId, true);
    
                // Get repository
                Repository repository = GetRepository(viewModel.RepositoryId);
    
                // Update properties
                contract.RepositoryId = repository.Id;
                contract.ConsumedUnits = repository.Units;
            } else {
        
                // assign repository
                UpdateRepositoryAssignment(viewModel.RepositoryId, true);
    
                // Get repository
                Repository repository = GetRepository(viewModel.RepositoryId);
    
                // Update properties
                contract.RepositoryId = repository.Id;
                contract.ConsumedUnits = repository.Units;
            }
        }
    
        UpdateContract(contract);
    }
