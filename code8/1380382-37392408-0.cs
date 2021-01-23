    public void SendAllEmails()
    {
        var emails = SomeClass.GetAllUnsentEmails();
        foreach(Email message in Emails)
        {
            var success = SendEmail(message);
            if (!success)
            {
                // Do you want to do something if it fails?
            }
        }
    }
    public bool SendEmail(Email message)
    {
        try
        {
            // 1. Send the email message
            // 2. Update the "SentOn" date in the database
            // 3. return true
        }
        catch(Exception ex)
        {
            SomeClass.CreateEmailErrorEntry(message, ex); // store error in a table or log
            return false;
        }
    }
