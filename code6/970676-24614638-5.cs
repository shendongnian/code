    private IntroductionBehavior introBehavior;
    public Person()
    {
        introBehavior = new IntroductionBehavior() { Name = "Test", Age = 123 };
    }
    public IIntroductionBehavior introductionBehavior
    {
        get { return introBehavior; }
    }
    public String Name
    {
        get { return introBehavior.Name; }
        set { introBehavior.Name = value; }
    }
    public Int32 Age
    {
        get { return introBehavior.Age; }
        set { introBehavior.Age = value; }
    }
