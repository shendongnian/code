    private int _foo; //Why create this?
    public int Foo
    {
        get { return Foo; } //this should not happen, wrong practice
        set
        {
            Foo = Foo; //neither should this happen, another wrong practice
        }
    }
