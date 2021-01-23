    public void SomeMethod ()
    {
        OtherMethod();
    }
    public void OtherMethod ([CallerMemberName] string memberName = null)
    {
        Console.WriteLine(memberName);
    }
