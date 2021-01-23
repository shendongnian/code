    public App()
    {
        BugSenseHandler.Instance.InitAndStartSession(new ExceptionManager(Current), RootFrame, "YourBugSenseApiKey");
        ...
    }
