    private ICollection<AggregationEntityViewModel> getEntities(
                  AggregationPracticeDetailsViewModel apdvm)
    {
        bool? filterInclude = apdvm.Filter_IncludeValue.GetValueOrNull<bool>();
    
        var a = (from e in _repository.GetAll<Entity>()                         
                 where !filterInclude.HasValue || ea.include == filterInclude.Value                     
                 select new AggregationEntityViewModel()
                 {
                    Include = newGroup.Key.ea == null 
                              ? (true || false) 
                              : (bool)newGroup.Key.ea.include,
                 }
        return a;
    }
