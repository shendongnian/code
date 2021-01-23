    public async Task UpdateContractWithRepository(ViewModel viewModel)
    {
        // Get the contract from db
        Contract contract = GetContract(viewModel.Id);
        bool modelRepositoryKnown = viewModel.RepositoryId != null;
        bool contractRepositoryKnown = contract.RepositoryId != null;
        if (modelRepositoryKnown)
        {
            if (contractRepositoryKnown)
            {
                // assign repository
                UpdateRepositoryAssignment(viewModel.RepositoryId, true);
                // Get repository
                Repository repository = GetRepository(viewModel.RepositoryId);
                // Update properties
                contract.RepositoryId = repository.Id;
                contract.ConsumedUnits = repository.Units;
            }
            else
            {
                // assign repository
                UpdateRepositoryAssignment(viewModel.RepositoryId, true);
                // Get repository
                Repository repository = GetRepository(viewModel.RepositoryId);
                // Update properties
                contract.RepositoryId = repository.Id;
                contract.ConsumedUnits = repository.Units;
            }
        }
        else if(contractRepositoryKnown)  // Model-Repository unknown but Contract-Repository Known
        {
            // Unassign Repository
            UpdateRepositoryAssignment(contract.RepositoryId, false);
            // Update properties
            contract.RepositoryId = null;
            contract.ConsumedUnits = null;
            break;
        }
        UpdateContract(contract);
    }
