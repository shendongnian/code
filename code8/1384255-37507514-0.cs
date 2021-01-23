                MailMessage mailObj = new MailMessage();
                //verification mail
                mailObj.Subject = "Your Email Subject line";
                mailObj.Body =  ComposeVerficationMailBody(emailDetails.MailMessage, emailDetails.RecipientName);
               emailDetails.SenderName = "Your Website Name";
                
                
                mailObj.IsBodyHtml = true;
                mailObj.Priority = System.Net.Mail.MailPriority.High;
                //TO
                mailObj.To.Add(emailDetails.RecipientEmailAddress);
                mailObj.BodyEncoding = Encoding.Default;
                mailObj.ReplyToList.Add(emailDetails.ReplyToEmailAddress);
                //From
                mailObj.From = new MailAddress(senderEmailAddress, senderDisplayName);
                using (SmtpClient mailClient = new SmtpClient())
                {
                    mailClient.Host = "gmail host";
                    mailClient.Port = 587;
                    mailClient.EnableSsl = false;
                    mailClient.UseDefaultCredentials = true;
                    mailClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    //mailClient.Credentials = new NetworkCredential("senderEmail", "senderPassword");
                   
                    MailAddress msg = new MailAddress(emailDetails.ReplyToEmailAddress);
                    mailClient.Timeout = 500000;
                    mailClient.Send(mailObj);
     private String ComposeVerficationMailBody()
     {
        StringBuilder emailMessage = new StringBuilder();
       //build your message here
       return emailMessage.toString();
     }
