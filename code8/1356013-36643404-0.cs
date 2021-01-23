    bool IsVMRepoNull = viewModel.RepositoryId == null;
    bool IsContractRepoNull = contract.RepositoryId == null;
    
    if(IsVMRepoNull && !IsContractRepoNull )
    {
      UpdateRepositoryAssignment(contract.RepositoryId, false);
    
     // Update properties
      contract.RepositoryId = null;
      contract.ConsumedUnits = null;
    }
    else if(!IsVMRepoNull)
    {
      UpdateRepositoryAssignment(viewModel.RepositoryId, true);
    
      // Get repository
      Repository repository = GetRepository(viewModel.RepositoryId);
    
      // Update properties
      contract.RepositoryId = repository.Id;
      contract.ConsumedUnits = repository.Units;
    }
