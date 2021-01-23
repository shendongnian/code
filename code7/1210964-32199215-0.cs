    public void UserMethod()
    {
        IntermediaryMethod();
    }
    public void IntermediaryMethod([CallerMemberName] caller = "")
    {
        LogMethod(caller)
    }
    public void LogMethod([CallerMemberName] caller = "")
    {
        // Log...
    }
