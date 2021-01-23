    var twilio = new TwilioRestClient(AccountSid, AuthToken); 
    
    // Build the parameters 
    var options = new MessageListRequest();    
    
    var messages = twilio.ListMessages(options); 
    foreach (var message in messages.Messages) 
    { 
     Console.WriteLine(message.Body); 
    } 
