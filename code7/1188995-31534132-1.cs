    private ISingleMailProcessor CreateMailProcessor(MailType type)
    {
      switch (type)
      {
          case MailConnector.MailType.AcronisBackup:
             return new AcronisProcessor();
          case ......etc.
      }
    }
    
    public MailResult GetMailResult(mail)
    {
      ISingleMailProcessor mailprocessor = CreateMailProcessor(mail.MailType);
      return mailprocessor.ProcesMail(mail);
    }
