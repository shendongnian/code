     MailMessage mail = new MailMessage();
                mail.Subject = subject;
                mail.Body = bodyhtml;
                mail.From = new MailAddress("myemail");
                mail.IsBodyHtml = true;
    
                foreach (string add in vendorEmailList.Split(','))
                {
                    if (string.IsNullOrEmpty(add))
                        continue;
    
                    mail.To.Add(new MailAddress(add));
                }
    
                foreach (string add in userEmailList.Split(','))
                {
                    if (string.IsNullOrEmpty(add))
                        continue;
    
                    mail.CC.Add(new MailAddress(add));
                }
    
                foreach (string path in attachments)
                {
                    //var bytes = File.ReadAllBytes(path);
                    //string mimeType = MimeMapping.GetMimeMapping(path);
                    Attachment attachment = new Attachment(path);//bytes, mimeType, Path.GetFileName(path), true);
                    mail.Attachments.Add(attachment);
                }
                MimeKit.MimeMessage mimeMessage = MimeMessage.CreateFromMailMessage(mail);
    
                Message message = new Message();
                message.Raw = Base64UrlEncode(mimeMessage.ToString());
                var result = gmailService.Users.Messages.Send(message, "me").Execute();
