    public ICollection<MyRowType> SomeOtherMethod(string id, SomeValue value = null, SomeOtherValue  otherValue = null) {
        Expression<Func<MyRowType,bool>> condition =
            r => r => r.Id == di;
        if (value != null)
            condition = condition.And(r => r.PropertyOne == value);
        if (otherValue != null)
            condition = condition.And(r => r.PropertyTwo == otherValue);
        return RunCommand(query);     
    }
