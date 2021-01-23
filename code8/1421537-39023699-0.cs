    var twilio = new TwilioRestClient([AccountSID], [AccountToken]);
    MessageListRequest request = new MessageListRequest();
    
    request.DateSent = Convert.ToDateTime("2016-08-01");
    request.DateSentComparison = ComparisonType.LessThanOrEqualTo;
    request.Count = 1000; // anything higher than this results in an error
    
    MessageResult messages = twilio.ListMessages(request);
    
    //Check for rest exceptions
    if (messages.RestException != null)
    {
        string exceptionMessage = "Code: " + messages.RestException.Code + "\nStatus: " + messages.RestException.Status + "\nMessage: " + messages.RestException.Message + "\nMoreInfo: " + messages.RestException.MoreInfo;
    
        MessageBox.Show(exceptionMessage, "API EXCEPTION: " + messages.RestException.Code + " >> " + messages.RestException.Status);
        Clipboard.SetData(DataFormats.StringFormat, messages.RestException.MoreInfo);
        return;
    }
