    using (var message = new MailMessage(fromAddress, toAddress)
                             {
                                 Subject = subject,
                                 Body = body,
                                 IsBodyHtml = true;
                             })
        {
            smtp.Send(message);
        }
