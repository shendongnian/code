    try {
    
        smtpClient.Send(mailMessage);    
    }
    catch (SmtpFailedRecipientsException recipientsException)
    {
       	Console.WriteLine($"Failed recipients: {string.Join(", ", recipientsException.InnerExceptions.Select(fr => fr.FailedRecipient))}");
     	
       	// your code here
    }
    catch (SmtpFailedRecipientException recipientException)
    {
     	Console.WriteLine($"Failed recipient: {recipientException.FailedRecipient}");
        
        // your code here
    }
    catch (SmtpException smtpException)
    {
      	Console.WriteLine(smtpException.Message);
        	
       	// your code here
    }
 
