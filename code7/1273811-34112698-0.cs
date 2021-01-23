    FireAndForgetTask(async cancellationToken =>
    {
                    using(var smtp = new SmtpClient
                    {
                        Host = "myhost",
                        Port = 587,
                        EnableSsl = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential("myemail", "mypass"),
                        Timeout = 50000
                    })
                    {          
                        using (var message = new MailMessage("myemail", destMail)
                        {
                            Subject = subject,
                            Body = mailBody,
                            IsBodyHtml = html           
                        })
                        {
                           await smtp.SendMailAsync(message);
                        }
                    }
    }
