    public IEnumerable<string> GetAll()
    {
        var managers = context.OWF_ManagerRelationship
            .Where(m => m.IsActive.Value)
            .Select(x => x.DisplayName);
        return managers;         
    }
