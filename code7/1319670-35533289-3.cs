    public Case GetById(int id)
    {
        Case oversightCase;
        if (context.Cases.OfType<Investigation>().Any(f => f.CaseId == id))
        {
            oversightCase = GetCaseCommonData<Investigation>()
                .Include(p => p.Investigatee)
                .SingleOrDefault(f => f.CaseId == id);
        }
        else
        {
            oversightCase = GetCaseCommonData<Case>()
                .SingleOrDefault(f => f.CaseId == id);
        }
        return oversightCase;
    }
