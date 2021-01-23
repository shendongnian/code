     public async Task<List<DependantViewModel>> SaveDependants(int customerId, List<DependantViewModel> dependantViewModels)
    {
        var dependantEntities = Mapper.Map<List<DependantViewModel>, List<Dependant>>(dependantViewModels);
        bool result = false;
        foreach (var dependantEntity in dependantEntities)
        {
            // Also InsertOrUpdate don't need to be async in that case
            _dependantRepository.InsertOrUpdate(dependantEntity);
            if (result != true)
            {
                // log errror
            }
        }
        // Let the SaveChanges be async
        result = await _dependantRepository.SaveChanges();
        return Mapper.Map<List<Dependant>, List<DependantViewModel>>(dependantEntities);
    }
BaseRepo:
    public async Task<bool> SaveChanges(){
       return await _context.SaveChangesAsync() != 0;
    }
