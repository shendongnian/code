        public static bool SendEmail(HttpPostedFileBase uploadedImage)
        {
            try
            {
                var message = new MailMessage 
                {
                    Subject = "This is subject.",
                    Body = "This is text."
                };
                if (uploadedImage != null && uploadedImage.ContentLength > 0)
                {
                    var attachment = new Attachment(uploadedImage.InputStream, uploadedImage.ContentType);
                    message.Attachments.Add(attachment);
                }
                message.IsBodyHtml = true;
                var smtpClient = new SmtpClient();
                
                //SMTP Credentials
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                //Logg exception
                return false;
            }
        }
