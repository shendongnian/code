    try
    {
       smtpClient.Send(new MailMessage("test@test.com", "test@test.com", "test", "test"));
       return string.Empty;
    }
    catch (SmtpFailedRecipientException)
    {
       return string.Empty;
    }
    catch (Exception ex)
    {
       return string.Format("SMTP server connection test failed: {0}", ex.InnerException != null ? ex.InnerException.Message : ex.Message);
    }
