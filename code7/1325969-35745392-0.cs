    private void ProcessMails()
    {
     while(true)
     {
      var mailsToBeProcessed = getAllMailsToBeProcessed(alreadySent, numOfMailsToBeProcessed);
       foreach(var mail in mailsToBeProcessed)
       {
         sendMail("mailsendingApiUrl", mail).Wait();
         alreadySent++;
       }
      }
    }
    private async void sendMail(string apiEndPoint, MailContent mailContent)
    {
        using (var client = new HttpClient())
        {
             await client.PostAsJsonAsync(apiEndPoint, mailContent.ContentId).ConfigureAwait(false);
        }
     }
