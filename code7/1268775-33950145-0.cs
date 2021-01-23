            private static void SendEmail(IEnumerable<string> attachmentFilePaths)
            {
                string fromEmail = "abcd@gmail.com ";
                string mail_add = "recever@gmail.com";
                string subject = "hello";
                string body = "How are you?";
                try
                {
                    using (MailMessage mailMessage = new MailMessage(fromEmail, mail_add, subject, body))
                    {
                        foreach (var attachmentFilePath in attachmentFilePaths)
                        {
                            if (File.Exists(attachmentFilePath))
                            {
                                Attachment attachement = new Attachment(attachmentFilePath);
                                mailMessage.Attachments.Add(attachement);
                            }
                        }
                        MailAddress copy = new MailAddress(fromEmail);
                        mailMessage.CC.Add(copy);
                        using (SmtpClient smtpClient = new SmtpClient())
                        {
                            smtpClient.Host = "smtp.gmail.com";
                            smtpClient.Port = 587;
                            smtpClient.EnableSsl = false;
                            smtpClient.UseDefaultCredentials = false;
                            smtpClient.Credentials = new NetworkCredential(fromEmail, "mis123");
                            smtpClient.Send(mailMessage);
                        }
                    }
                }catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
