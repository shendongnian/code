    public IEnumerable<string> GetAll()
    {
        var managers = context.OWF_ManagerRelationship
            .Where(m => m.IsActive.Value == true)
            .Select(x => x.DisplayName);
        return managers;         
    }
