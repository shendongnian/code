       var x = context.Tables
        .Where(t => t.ProjectId == projectId)
        .Select(t => new TableViewModel()
        {
            Question = t.Question,
            ProjectId = t.ProjectId,
            QOrder = t.QOrder
        })        
        .Distinct(comparer: new TableViewModelComparer ())
        .OrderBy(t => t.QOrder)
        .ToList();
    return x;
