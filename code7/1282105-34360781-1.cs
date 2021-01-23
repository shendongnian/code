    public IReadOnlyList<ObjectiveListVM> GetSummaryList()
    {
        return _repository
            .GetList()
            .Select(o => new ObjectiveListVM
            {
                ObjectiveId = o.ObjectiveId,
                ObjectiveDescription = o.ObjectiveDescription,
                StartDate = o.StartDate
            })
            .ToList();
    }
