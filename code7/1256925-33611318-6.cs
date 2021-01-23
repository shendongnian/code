    public void SendMails(List<string> list)
    {
        Task.Run(() =>
        {
            foreach (var item in list)
            {
                //Put all send mail codes here 
                //...
                //mail.To.Add(new MailAddress(item));
                //client.Send(mail);
            }
        });
    }
