    try
    {
        SMTP.Send(Message);                
    }
    catch (SmtpFailedRecipientsException exs)
    {
        foreach (SmtpFailedRecipientException e in exs)
        {
            if (e.FailedRecipient.ToString() != data.SenderReply.Replyer)
            {
                 Failed.Add(e.FailedRecipient.ToString());
            }
        }
    }
    catch (SmtpFailedRecipientException e)
    {
        if (e.FailedRecipient.ToString() != data.SenderReply.Replyer)
        {
             Failed.Add(e.FailedRecipient.ToString());
        }
    }
    finally
    {
        SMTP.Dispose();
    }
