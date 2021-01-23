    List<Int32> projectIds = new List<Int32>();
    foreach (Project p in ProjectList)
        projectIds.Add(p.Id);
    Expression<Func<ContractObject, bool>> objExpression = 
    i => i.ContractProjects.Where(a => projectIds.Contains(a.ProjectId)).Any()
