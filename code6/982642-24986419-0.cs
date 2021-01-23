    public int DoSomething(SomeObject o, int i)
    {
        Contract.Requires(o != null);
        Contract.Requires(i > 0);
        // You could combine the conditionals in the Requires: o != null && i > 0
        Contract.Ensures(/* some post condition */);
        int returnValue = 0;
        // Do some stuff
        return returnValue;
    }
    public void SomeMethodThatDoesSomething(int i)
    {
        Contract.Requires(i > 0)
        // Do some stuff
    }
    public void SomeMethodThatCoordinatesActivities()
    {
        int result = DoSomething(new SomeObject(), 10);
        Contract.Assume(result > 0);
        SomeMethodThatDoesSomething(result);
    }
