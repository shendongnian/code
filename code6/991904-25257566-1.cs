    private ICollection<AggregationEntityViewModel> getEntities(AggregationPracticeDetailsViewModel apdvm)
    {
        var query = _repository.GetAll<Entity>();
        if(apdvm.Filter_IncludeValue != 'all')
        {
            var value = Convert.ToBoolean(apdvm.Filter_IncludeValue);
            query = query.Where(q => q.include == value)
        }
        return query.Select(q => new AggregationEntityViewModel {...}).ToArray();
    } 
