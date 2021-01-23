    public void SomeMethod ()
    {
        OtherMethod();
    }
    public void OtherMethod ([CallerMemberName] $memberName = null)
    {
        Console.WriteLine($memberName);
    }
