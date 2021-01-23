    SmtpClient smtpClient = new SmtpClient(WebMail.SmtpServer);
                MailMessage email1 = new MailMessage();
                email1.IsBodyHtml = true;
                email1.From = new MailAddress("from@email.com");
                email1.To.Add(new MailAddress(sendemail));
                //email1.CC.Add(new MailAddress("carboncopy@foo.bar.com"));
                email1.Body = BodyTemplate;
                email1.Subject = "Please reset your password";
    
                var stream = new System.IO.MemoryStream(pdfBytes);
                email1.Attachments.Add(new Attachment(stream, "invoice.pdf"));
                smtpClient.Send(email1);
