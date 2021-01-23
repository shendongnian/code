    public void Dispose()
    {
        if (_accounts != null) 
        {
            Logger.Trace("Disposing of Acccounts...");
            Accounts.Dispose();
            // or
            // _accounts.Dispose();
            // _accounts = null;
        }
        if (_attachments != null) 
        {
            Logger.Trace("Disposing of Attachments...");
            Attachments.Dispose();
            // or
            // _attachments.Dispose();
            // _attachments = null;
        }
        if (_cases != null) 
        {
            Logger.Trace("Disposing of Cases...");
            Cases.Dispose();
            // or
            // _cases.Dispose();
            // _cases= null;
        }
        if (_contacts != null) 
        {
            Logger.Trace("Disposing of Contacts...");
            Contacts.Dispose();
            // or
            // _contacts.Dispose();
            // _contacts = null;
        }
        if (_groups != null) 
        {
            Logger.Trace("Disposing of Groups...");
            Groups.Dispose();
            // or
            // _groups.Dispose();
            // _groups = null;
        }
        if (_recordTypes != null) 
        {
            Logger.Trace("Disposing of RecordTypes...");
            RecordTypes.Dispose();
            // or
            // _recordTypes.Dispose();
            // _recordTypes = null;
        }
        if (_users!= null) 
        {
            Logger.Trace("Disposing of Users...");
            Users.Dispose();
            // or
            // _users.Dispose();
            // _users= null;
        }
    }
