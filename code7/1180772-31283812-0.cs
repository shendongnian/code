     public async Task<List<DependantViewModel>> SaveDependants(int customerId, List<DependantViewModel> dependantViewModels)
    {
        var dependantEntities = Mapper.Map<List<DependantViewModel>, List<Dependant>>(dependantViewModels);
        bool result = false;
        foreach (var dependantEntity in dependantEntities)
        {
            // Also InsertOrUpdate don't need to be async in that case
            _dependantRepository.InsertOrUpdate(dependantEntity);
            result = _dependantRepository.SaveChanges();
            if (result != true)
            {
                // log errror
            }
        }
        return Mapper.Map<List<Dependant>, List<DependantViewModel>>(dependantEntities);
    }
BaseRepo:
    public async Task<bool> SaveChanges(){
       return await _context.SaveChangesAsync() != 0;
    }
