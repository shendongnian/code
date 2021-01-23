    private ICollection<AggregationEntityViewModel> getEntities(AggregationPracticeDetailsViewModel apdvm)
    {
        bool? filterInclude = Convert.ToBoolean(apdvm.Filter_IncludeValue);
        var query = _repository.GetAll<Entity>();
        if(filterInclude.HasValue)
        {
            var value = Convert.ToBoolean(filterInclude.Value);
            query = query.Where(q => q.include == value)
        }
        return query.Select(q => new AggregationEntityViewModel {...}).ToArray();
    } 
