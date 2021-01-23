    var errorList = new ConcurrentBag<string>();
    Parallel.ForEach(emailList, email =>
    {
         try
         {
             Mail.SendMail(tbEmailFrom.Text, email.ToString(), tbEmailCC.Text, tbEmailBC.Text, tbReplyTo.Text, DotNetNuke.Services.Mail.MailPriority.Normal,
             tbSubject.Text, MailFormat.Html, System.Text.Encoding.UTF8, tbEmailBody.Text, attachments, smtpServer, smtpAuthentication, smtpUsername, smtpPassword, false);
             Interlocked.Increment(ref count);  
         }
         catch(SmtpException stmp)
         {
             Exceptions.LogException(smtp);
             errorList.Add(email);
         }   
    });
    RadRadialGauge1.Pointer.Value = count;
