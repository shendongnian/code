    public void Dispose()
    {
        if (_accounts != null) 
        {
            Logger.Trace("Disposing of Acccounts...");
            Accounts.Dispose();
        }
        if (_attachments != null) 
        {
            Logger.Trace("Disposing of Attachments...");
            Attachments.Dispose();
        }
        if (_cases!= null) 
        {
            Logger.Trace("Disposing of Cases...");
            Cases.Dispose();
        }
        if (_contacts != null) 
        {
            Logger.Trace("Disposing of Contacts...");
            Contacts.Dispose();
        }
        if (_groups != null) 
        {
            Logger.Trace("Disposing of Groups...");
            Groups.Dispose();
        }
        if (_recordTypes != null) 
        {
            Logger.Trace("Disposing of RecordTypes...");
            RecordTypes.Dispose();
        }
        if (_users!= null) 
        {
            Logger.Trace("Disposing of Users...");
            Users.Dispose();
        }
    }
