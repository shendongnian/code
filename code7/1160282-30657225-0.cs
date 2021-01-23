    protected override void OnBeforeInstall(IDictionary savedState)
    {
        string parameter = "MySource1\" \"MyLogFile1";
        Context.Parameters["assemblypath"] = "\"" + Context.Parameters["assemblypath"] + "\" \"" + parameter + "\"";
        base.OnBeforeInstall(savedState);
    }
