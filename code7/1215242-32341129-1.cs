    // flat strings...
    if (this.Log.IsInfoEnabled)
        this.Log.Info("I've been navigated to.");
    // formatting...
    if (this.Log.IsDebugEnabled)
        this.Log.Debug("I can also format {0}.", "strings");
    // errors...
    try
    {
        this.DoMagic();
    }
    catch(Exception ex)
    {
        if (this.Log.IsWarnEnabled)
            this.Log.Warn("You can also pass in exceptions.", ex);
    }
