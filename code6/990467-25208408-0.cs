    public SmsMessageResult MyListSmsMessages(
        string to = null, string from = null, DateTime? dateSent = null, int? pageNumber = null, int? count = null)
    {
      return client.ListSMSMessages("to", null, date, null, null); 
    }
