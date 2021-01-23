    public DemoIndexQuery ByFirstName(string firstName)
    {
        And(p => p.Term(term => term.FirstName, firstName));
        return this;
    }
