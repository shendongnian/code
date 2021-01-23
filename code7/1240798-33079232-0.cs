    public void SomeMethod ()
    {
        Console.WriteLine(GetMethodName());
    }
    // assuming that a CallingMemberNameAttribute existed
    public string GetMethodName([CallingMemberName] string callingMember = null)
    {
        return callingMember; // would be always "GetMethodName"
    }
