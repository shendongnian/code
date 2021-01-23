    if(viewModel.RepositoryId == null && !contract.RepositoryId)
	{
        // Unassign Repository
        UpdateRepositoryAssignment(contract.RepositoryId, false);
        // Update properties
        contract.RepositoryId = null;
        contract.ConsumedUnits = null;
	}
	else if(!viewModel.RepositryId && contract.RepositoryId == null)
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
