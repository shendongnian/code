    StringBuilder builder = new StringBuilder();
    foreach (Outlook.Account account in accounts)
    {
       // The DisplayName property represents the friendly name of the account.
       builder.AppendFormat("DisplayName: {0}\n", account.DisplayName);
       // The UserName property provides an account-based context to determine identity.
       builder.AppendFormat("UserName: {0}\n", account.UserName);
       // The SmtpAddress property provides the SMTP address for the account.
       builder.AppendFormat("SmtpAddress: {0}\n", account.SmtpAddress);
       // The AccountType property indicates the type of the account.
       builder.Append("AccountType: ");
       switch (account.AccountType)
       {
          case Outlook.OlAccountType.olExchange:
               builder.AppendLine("Exchange");
               break;
          case Outlook.OlAccountType.olHttp:
               builder.AppendLine("Http");
               break;
          case Outlook.OlAccountType.olImap:
               builder.AppendLine("Imap");
               break;
          case Outlook.OlAccountType.olOtherAccount:
               builder.AppendLine("Other");
               break;
          case Outlook.OlAccountType.olPop3:
               builder.AppendLine("Pop3");
               break;
       }
       builder.AppendLine();
    }
