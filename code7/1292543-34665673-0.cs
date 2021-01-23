    public void Dispose()
    {
        Logger.Trace("Disposing of Acccounts...");
        if(_accounts != null) _accounts.Dispose();
        Logger.Trace("Disposing of Attachments...");
        if(_attachments != null) _attachments.Dispose();
        // ...
    }
