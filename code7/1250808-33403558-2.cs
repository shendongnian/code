    public void Test()
    {
        IEnumerable<SomeClass> list = GetList();
        IQueryable<SomeClass> repo = GetQuery();
        var r0 = list.Where( SomeClassMeetsConditionName.Delegate );
        var r1 = repo.Where( SomeClassMeetsConditionName.Expression );
    }
