    public void ProcessThread(object parameter)
    {
        var record = (QMail)parameter;
        _logging = new AutoQueueLog(record.UID.ToString(), "Sending Mails", record.Subject, "Processing");
        _logging.Path = @"C:\Windows Services\QueueMailing\AutoLog";
        _logging.LogMessage();
        try
        {
            SendMail(record);
            record.SetDone();
            _logging.State = "Done";
            _logging.LogMessage();
        }
        catch (Exception ex)
        {
            _logging.State = "Error";
            _logging.LogException = ex;
            _logging.Level = AutoLog.ExceptionLevel.Major;
            _logging.LogMessage();
        }
        finally
        {
            m_numActive--;
        }
    }
