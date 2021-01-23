    public Action Find(SomeType someParameter)
    {
        if (someCondition)
        {
            return new Action(() => Method1());
        }
        else
        {
            return new Action(() => Method2());
        }
    }
