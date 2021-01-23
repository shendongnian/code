    private List<ParentVM> MapRepositoryToViewClasses(List<Parent> parents)
    {
        // Factory instance can be provided by the outer scope
        var factory = new VMFactory();
        var parentsVM = new List<ParentVM>();
        foreach (var item in parents)
        {
            parentsVM.Add(factory.Create(item));
        }
        
        return parentsVM;
    }
