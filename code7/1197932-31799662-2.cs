    public ActionResult SendEmail()
    {
     MailMessage msg = new MailMessage()
                {
                    Subject = "Your Subject",
                    Body = "<html><body><table border='1'><tr>Hello, World, from Gmail API!<td></td></tr></table></html></body>",
                    From = new MailAddress("from@email.com")
                };
                msg.To.Add(new MailAddress("to@email.com"));
                msg.ReplyToList.Add(new MailAddress("to@email.com")); // important! if no ReplyTo email will bounce back to the sender.
    
    Gmail gmail = new Gmail(new ClientSecrets() { ClientId = "client_id", ClientSecret = "client_secret" }, "your project name");
    gmail.SendEmail(msg);
    }
