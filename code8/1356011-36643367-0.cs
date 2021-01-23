    public async Task UpdateContractWithRepository(ViewModel viewModel){
            Contract contract = GetContract(viewModel.Id);
            if (viewModel.RepositoryId == null)
            {
                if(contract.RepositoryId != null){
                    UpdateRepositoryAssignment(contract.RepositoryId, false);
                    contract.RepositoryId = null;
                    contract.ConsumedUnits = null;
                }
            }
            else
            {
                if (contract.RepositoryId == null)
                {
                    UpdateRepositoryAssignment(viewModel.RepositoryId, true);
                    Repository repository = GetRepository(viewModel.RepositoryId);
                    contract.RepositoryId = repository.Id;
                    contract.ConsumedUnits = repository.Units;
                }
                else
                {
                    UpdateRepositoryAssignment(viewModel.RepositoryId, true);
                    Repository repository = GetRepository(viewModel.RepositoryId);
                    contract.RepositoryId = repository.Id;
                    contract.ConsumedUnits = repository.Units;
                }
            }
            UpdateContract(contract);
        }
