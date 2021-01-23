    private static readonly Apple a, c;
    private readonly Orange b;
    static SomeClass()
    {
        // this is fine
        a = new Apple();
        // there is no workaround
        // b isn't available yet
        c = new Apple(b.getDna());
    }
    
    public SomeClass()
    {
        // this is fine
        b = new Orange(a.getDna());
    }
