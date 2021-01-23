      public void SendEmailWithAttachment()
            {
                var objMailMessage = new MailMessage("EnterFromEmailAddress", "ReceiverEmailAddress")
                {
                    Subject = "EnterEmailSubject",
                    IsBodyHtml = true,
                    Body = "EnterEmailBody"
                };
                //You can add more attachments
                objMailMessage.Attachments.Add(new Attachment("EnterAttachmentLocationPath")); 
                var smtp = new SmtpClient("smtp.office365.com");
                var login = new NetworkCredential("SenderEmail","SenderEmailPAssword");
                smtp.Credentials = login;
                smtp.Port =  587;
                smtp.EnableSsl = true; 
                smtp.Send(objMailMessage); 
            } 
    
