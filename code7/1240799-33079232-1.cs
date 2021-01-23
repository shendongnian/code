    public void SomeMethod ()
    {
        Console.WriteLine(GetMethodName());
    }
    public string GetMethodName([CallerMemberNamed] string callerMember = null)
    {
        return callerMember;
    }
